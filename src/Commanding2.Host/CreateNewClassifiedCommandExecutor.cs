using System;

using Ncqrs.Commanding.CommandExecution;
using Ncqrs.Domain;

using NAd.Domain;

namespace Commanding2.Host
{
    //public class CreateNewClassifiedCommandExecutor : CommandExecutorBase<CreateNewClassifiedCommand>
    //{
    //    protected override void ExecuteInContext(IUnitOfWorkContext context, CreateNewClassifiedCommand command)
    //    {
    //        var newClassified = new Classified(Guid.NewGuid(), command.Name, command.Description);

    //        context.Accept();
    //    }
    //}
}