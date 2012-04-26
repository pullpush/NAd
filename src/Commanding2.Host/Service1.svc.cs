using System.ServiceModel;

using Ncqrs;
using Ncqrs.Commanding.ServiceModel;

namespace Commanding2.Host
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        //static Service1()
        //{
        //    //Bootstrapper.BootUp();
        //}

        public void Execute(CreateNewClassifiedCommand command)
        {
            //var service = NcqrsEnvironment.Get<ICommandService>();
            //service.Execute(command);
        }
    }
}
