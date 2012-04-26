using System;

using Autofac;

namespace NAd.Querying.Core.Common
{
    /// <summary>
    /// A facade that provides access to a global instance of the <see cref="IIocContainer"/> interface.
    /// </summary>
    public static class Ioc
    {
        [ThreadStatic]
        public static IContainer LocalContainer;

        private static IContainer container;

        public static IContainer Global
        {
            get
            {
                if ((container == null) && (LocalContainer != null))
                {
                    return LocalContainer;
                }
                else if (container == null)
                {
                    return new ContainerBuilder().Build();
                }
                else
                {
                    return container;
                }
            }
            set { container = value; }
        }

        //public static TService Resolve<TService>()
        //{
        //    return container.Resolve<TService>();
        //}
    }
}