using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;

namespace Exiled_Plugin_Tutorial.Commands
{
    class Allow : ICommand
    {
        public string Command { get; } = "Allow";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "A command that is allowed";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "The command did worked!";
            return true;
        }
    }
}
