using System.Collections.Generic;
using System.Linq;

namespace simple.migrations
{
    public class ConsoleArgumentsCommandRegistry : CommandRegistry
    {
        readonly IList<ConsoleCommand> all_commands = new List<ConsoleCommand>();

        public ParameterizedCommand<ConsoleArguments> command_for(string[] arguments)
        {
            if(all_commands.Any(x => x.can_handle(arguments)))
                return all_commands.Single(x => x.can_handle(arguments));
            return new HelpCommand();
        }

        public void register(ConsoleCommand command)
        {
            all_commands.Add(command);
        }
    }
}