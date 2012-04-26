
using System;

using NAd.UI.Commanding;

namespace NAd.UI.Services
{
    public interface ICommandAgent
    {
        void Send(CommandBase command);
    }
}