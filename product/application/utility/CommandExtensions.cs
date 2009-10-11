namespace gorilla.migrations.utility
{
    static public class CommandExtensions
    {
        static public Command then(this Command first_command, Command next_command)
        {
            return new CompositeCommand(first_command, next_command);
        }
    }
}