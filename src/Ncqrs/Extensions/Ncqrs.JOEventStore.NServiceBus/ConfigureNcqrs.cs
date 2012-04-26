using Ncqrs;
using Ncqrs.Commanding.CommandExecution.Mapping;
using Ncqrs.Domain;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using Ncqrs.JOEventStore.NServiceBus;

namespace NServiceBus
{
    public static class ConfigureNcqrs
    {
        /// <summary>
        /// Instructs NServiceBus to install Ncqrs environment.
        /// 
        /// </summary>
        /// <param name="config">The config object.</param>
        /// <returns></returns>
        public static ConfigNcqrs InstallNcqrs(this Configure config)
        {            
            var configNcqrs = new ConfigNcqrs();
            configNcqrs.Configure(config);
            return configNcqrs;
        }
    }
}