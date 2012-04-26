// Type: System.Collections.Generic.KeyNotFoundException
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Collections.Generic
{
    [ComVisible(true)]
    [Serializable]
    public class KeyNotFoundException : SystemException, ISerializable
    {
        public KeyNotFoundException();
        public KeyNotFoundException(string message);
        public KeyNotFoundException(string message, Exception innerException);

        [SecuritySafeCritical]
        protected KeyNotFoundException(SerializationInfo info, StreamingContext context);
    }
}
