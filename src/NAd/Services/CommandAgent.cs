
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using NAd.UI.Commanding;
//using NAd.UI.Views;

namespace NAd.UI.Services
{
    public class CommandAgent : ICommandAgent
    {
        private readonly IBusyService busyService;

        public CommandAgent(IBusyService busyService)
        {
            this.busyService = busyService;
        }

        public void Send(CommandBase command)
        {
            busyService.MarkAsBusy();

            var commands = new List<CommandBase> {command};

            var service = new NAdCommandServiceClient();
            //service.ExecuteCompleted += OnExecuteCompleted;
            //service.ExecuteAsync(new ObservableCollection<Command>(commands), commands);
        }

        private void OnExecuteCompleted(object sender, AsyncCompletedEventArgs e)
        {
            busyService.UnmarkAsBusy();

            if (e.Error != null)
            {
                Exception exception = ServiceAgentExceptionPolicy.Process(e.Error);

                //new ErrorWindow(exception).Show();
            }
        }
    }
}