namespace gorilla.migrations.utility
{
    public class CompositeCommand : Command
    {
        readonly Command left;
        readonly Command right;

        public CompositeCommand(Command left, Command right)
        {
            this.left = left;
            this.right = right;
        }

        public void run()
        {
            left.run();
            right.run();
        }
    }
}