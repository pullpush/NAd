//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;

//using Microsoft.Practices.Unity;

//using Ncqrs.CommandHandling;
//using Ncqrs.Infrastructure;
//using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
//using Ncqrs.Commanding.CommandExecution;
 
using NAd.Commanding.Commands;
using NAd.Commanding.ExceptionHandling;

namespace NAd.Commanding
{
    /// <summary>
    /// Service interface that accepts one or more commands to be executed at the classifieds domain model.
    /// </summary>
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    //[ServiceKnownType("GetKnownTypes")]
    [ExceptionShieldingBehavior]
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class NAdCommandService : INAdCommandService
    {
        //private static ICommandExecutor<ServicedCommand> executor;
        //private INAdCommandService service;
        //private static ICommandService commandService;
        private readonly ICommandService _commandService;

        /// <summary>
        /// Initializes the <see cref="CommandService"/> class.
        /// </summary>
        //static NAdCommandService()
        //{
        //    //Bootstrapper.BootUp();

        //    commandService = NcqrsEnvironment.Get<ICommandService>();

        //    //executor = ServiceLocator.Current.Resolve<ICommandExecutor>();
        //}
        public NAdCommandService(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [FaultContract(typeof(ApplicationErrorFault))]
        [FaultContract(typeof(RuleViolationFault))]
        public void Execute(CreateNewClassifiedCommand command)
        {
            //var commandService = NcqrsEnvironment.Get<ICommandService>();
            _commandService.Execute(command);
        }

        /// <summary>
        /// Executes the specified commands.
        /// </summary>
        /// <param name="commands">The commands.</param>
        //[OperationContract]
        //public void Execute(IEnumerable<ServicedCommand> commands)
        //{
        //    try
        //    {
        //        foreach (var command in commands)
        //        {
        //            executor.Execute(command);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new FaultException(e.Message);
        //    }
        //}

        //public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        //{
        //    var query =
        //        from type in typeof(ServicedCommand).Assembly.GetTypes()
        //        where typeof(ServicedCommand).IsAssignableFrom(type)
        //        select type;

        //    return query.ToArray();
        //}
    }
}
