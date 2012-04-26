
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;

namespace NAd.Common.ExceptionHandling
{
   /// <summary>
   /// Provides helper methods for generating a full process dump, including stack details and the exception hierarchy.
   /// </summary>
   public static class ExceptionHelper
   {
      /// <summary>
      /// Generates a full process dump including all threads and modules.
      /// </summary>
      /// <param name="exception">
      /// The exception hierarchy to include in the process dump.
      /// </param>
      public static string [] GenerateProcessDump(Exception exception)
      {
         // Keep a reference which we can use to traverse the inner 
         // exceptions.
         Exception tempException = exception;

         // Create some storage to put the process dump in. We don't want
         // to call any SystemMessage objects until all threads have been
         // resumed. If we do, we might run into a deadlock. 
         var bucket = new List<string>();

         // Recursively traverse all exceptions in the exception 
         // hierarchy.
         while (tempException != null)
         {
            Add(bucket, "CALL STACK OF EXCEPTION {0}: {1}", tempException.GetType().Name, tempException.Message);

            if (tempException.StackTrace != null)
            {
               string [] frames = tempException.StackTrace.Split('\n');
               foreach (string frame in frames)
               {
                  Add(bucket, frame.Replace("\r", "").Replace("   ", "\t"));
               }
            }
            else
            {
               Add(bucket, "\t(no stacktrace available)");
            }

            Add(bucket, "END OF CALL STACK");
            Add(bucket, "");

            tempException = tempException.InnerException;
         }

         GenerateStackDump(bucket);
         GenerateHttpContextDump(bucket);
         GenerateBrowserCapabilitiesDump(bucket);

         Add(bucket, "END OF LIST");
         Add(bucket, "");

         return bucket.ToArray();
      }

      private static void GenerateHttpContextDump(IList bucket)
      {
         if (HttpContext.Current != null)
         {
            Add(bucket, "ASP.NET CONTEXT");
            Add(bucket, "\tRequest Url: {0}", HttpContext.Current.Request.Url);
            Add(bucket, "\tUser IP address: {0}", HttpContext.Current.Request.UserHostAddress);
            Add(bucket, "END OF ASP.NET CONTEXT");
            Add(bucket, "");
         }
      }

      private static void GenerateBrowserCapabilitiesDump(IList bucket)
      {
         if (HttpContext.Current != null)
         {
            HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;

            Add(bucket, "BROWSER CAPABILITIES");
            Add(bucket, "\tName: {0}", browser.Browser);
            Add(bucket, "\tVersion: {0}", browser.Version);
            Add(bucket, "\tPlatform = " + browser.Platform);
            Add(bucket, "\tECMA Script version = " + browser.EcmaScriptVersion);
            Add(bucket, "END OF BROWSER CAPABILITIES");
            Add(bucket, "");
         }
      }

      /// <summary>
      /// Helper function that adds a formatted string to an 
      /// <see cref="IList{T}"/>.
      /// </summary>
      private static void Add(IList list, string message, params object [] arguments)
      {
         list.Add(string.Format(message, arguments));
      }

      /// <summary>
      /// Generates a stack dump of all threads.
      /// </summary>
      /// <param name="bucket">String-based list for storing the results.
      /// </param>
      private static void GenerateStackDump(IList bucket)
      {
         Thread current = Thread.CurrentThread;

         // Dump the state of the current thread.
         Add(bucket, "CALL STACK OF CURRENT THREAD ({0})", current);
         GenerateStackDump(bucket, current, 4);
         Add(bucket, "END OF CALL STACK");
         Add(bucket, "");
      }


      /// <summary>
      /// Generates a stack dump of the specified thread.
      /// </summary>
      /// <remarks>
      /// The format of the stack dump will look similar to the StackTrace 
      /// property of an exception.
      /// </remarks>
      /// <param name="thread">The thread to analyse.</param>
      /// <param name="framesToSkip">The number of stack frames to skip 
      /// starting with the most recent one.</param>
      /// <param name="bucket">String-based list for storing the results.
      /// </param>
      private static void GenerateStackDump(IList bucket, Thread thread, int framesToSkip)
      {
         // Get the stack trace and iterate through its frames.
         var stack = new StackTrace(thread, true);

         for (
            int frameIndex = framesToSkip;
            frameIndex < stack.FrameCount;
            ++frameIndex)
         {
            // Get the frame and corresponding method
            StackFrame frame = stack.GetFrame(frameIndex);
            MethodBase method = frame.GetMethod();

            var b = new StringBuilder("\tat ");

            // Begin with the fully qualified name of the method (including
            // namespace and declaring type).
            string fullName = method.DeclaringType != null ? method.DeclaringType.FullName : "<unknown>";
            b.AppendFormat("{0}.{1}(", fullName, method.Name);

            // Add the name and type of all the arguments to the method
            // description.
            ParameterInfo [] parInfoList = method.GetParameters();
            for (int i = 0; i < parInfoList.Length; ++i)
            {
               ParameterInfo info = parInfoList[i];
               if (i > 0)
               {
                  b.AppendFormat(", ");
               }
               b.AppendFormat(
                  "{0} {1}",
                  info.ParameterType.Name,
                  info.Name);
            }
            b.Append(") in ");

            // Try to find the filename and linenumber and add this to the
            // description as well. Notice that this only works if the PDB
            // is there.
            string fileName = frame.GetFileName();
            if (fileName != null)
            {
               b.Append(fileName);
               b.Append(":");
               b.Append(frame.GetFileLineNumber());
            }

            bucket.Add(b.ToString());
         }
      }
   }
}