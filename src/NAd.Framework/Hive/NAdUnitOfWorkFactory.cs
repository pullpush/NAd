
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NAd.Framework.Persistence.Abstractions;

namespace NAd.Framework.Hive
{
    //public delegate T NAdUnitOfWorkFactoryDelegate<out T>(IDataMapper mapper) where T: class;

    //public static class SimpleRepositoryFactory
    //{
    //    private static Dictionary<Type, Type> repositoryTypes =
    //        new Dictionary<Type, Type>();

    //    /// <summary>
    //    /// Creates repository object based on its interface
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="args"></param>
    //    /// <returns></returns>
    //    public static T Create<T>(params object[] args)
    //    {
    //        if (repositoryTypes.ContainsKey(typeof(T)))
    //        {
    //            // Create InternalRepositoryFactory<I, C>.
    //            Type internalFactory =
    //                typeof(InternalRepositoryFactory<,>);
    //            internalFactory = internalFactory.MakeGenericType(
    //                typeof(T), repositoryTypes[typeof(T)]);

    //            // Get the Create() method from the
    //            // InternalRepositoryFactory.
    //            MethodInfo method = internalFactory.GetMethod(
    //                "Create", BindingFlags.Static |
    //                BindingFlags.NonPublic);

    //            // Invoke the Create() method and return the result.
    //            // For some reason I need to wrap 'args' into a new
    //            // object[]?
    //            return (T)method.Invoke(
    //                internalFactory, new object[] { args });
    //        }
    //        else
    //        {
    //            throw new Exception("Type: " + typeof(T)
    //                + " does not exist in dictionary. Register"
    //                + " the type mappings first by using the"
    //                + " RegisterTypeMapping method.");
    //        }
    //    }

    //    /// <summary>
    //    /// Registers the repository types, marking them as
    //    /// available to use with the RepositoryFactory.
    //    /// </summary>
    //    /// <typeparam name="I">Interface type of object.</typeparam>
    //    /// <typeparam name="C">Concrete type of object.</typeparam>
    //    public static void RegisterTypeMapping<I, C>()
    //    {
    //        // Only add the type mapping if it doesn't exist.
    //        if (!typeMapping.ContainsKey(typeof(I)))
    //            typeMapping.Add(typeof(I), typeof(C));
    //    }
    //}
}
