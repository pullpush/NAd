using System.Collections.Generic;
using System.ServiceModel;

using NAd.Commanding.Commands;

namespace NAd.Commanding
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommandService" in both code and config file together.
    [ServiceContract(Namespace = "")]
    public interface INAdCommandService
    {
        [OperationContract]
        void Execute(CreateNewClassifiedCommand command);

        //[OperationContract]
        //void Execute(IEnumerable<ServicedCommand> commands);
    }
}
