using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;

namespace Exiled_Plugin_Tutorial.Commands
{
    class Deny : ICommand
    {
        public string Command { get; } = "Deny";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "A command that is denied";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "The command didn't work!";
            return false;
        }
    }
}
