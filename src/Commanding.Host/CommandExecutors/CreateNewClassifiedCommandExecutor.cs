using System;

using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;

using NAd.Ncqrs.Domain;
using NAd.Commanding.Commands;

namespace NAd.Commanding.CommandExecutors
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// WRIRE side.
    /// Command executors should not contain any business logic!!!
    /// The only thing they do is making changes to aggregate roots from the domain and makes changes to them. 
    /// To stay away from plumbing code, Ncqrs supports mapping for command to map a command directly to an domain object.
    /// WRIRE side.
    /// Command executors make changes to aggregate roots in the domain. 
    /// All business logic is captured within these objects and is not used for querying. 
    /// This allows us to optimize this model for behavior.
    /// </remarks>
    //public class CreateNewClassifiedCommandExecutor : CommandExecutorBase<CreateNewClassifiedCommand>
    //{
    //    protected override void ExecuteInContext(IUnitOfWorkContext context, CreateNewClassifiedCommand command)
    //    {
    //        var newClassified = new Classified(Guid.NewGuid(), command.Name, command.Description);

    //        context.Accept();
    //    }
    //}
}