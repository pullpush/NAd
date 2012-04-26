// Type: Ncqrs.CommandService.Contracts.ExecuteRequest
// Assembly: Ncqrs.CommandService.Contracts, Version=1.0.0.0, Culture=neutral
// Assembly location: D:\Projects\Workshop\NAd\Libs\debug\Ncqrs.CommandService\Ncqrs.CommandService.Contracts.dll

using Ncqrs.Commanding;
using System.ServiceModel;

namespace Ncqrs.CommandService.Contracts
{
    [MessageContract(WrapperName = "ExecuteRequest", WrapperNamespace = "http://ncqrs.org/services/2010/12/data/")]
    public class ExecuteRequest
    {
        public ExecuteRequest();
        public ExecuteRequest(CommandBase command);

        [MessageBodyMember]
        public CommandBase Command { get; set; }
    }
}
