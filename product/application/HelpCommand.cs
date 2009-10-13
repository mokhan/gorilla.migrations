using System;

namespace gorilla.migrations
{
    public class HelpCommand : ConsoleCommand
    {
        public void run_against(ConsoleArguments item)
        {

            System.Console.Out.WriteLine("Please provide the correct arguments");
        }

        public bool can_handle(ConsoleArguments arguments)
        {
            throw new NotImplementedException();
        }
    }
}