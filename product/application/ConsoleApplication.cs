namespace simple.migrations
{
    public class ConsoleApplication : Console
    {
        readonly ConsoleController controller;

        public ConsoleApplication(ConsoleController controller)
        {
            this.controller = controller;
        }

        public void run_against(string[] item)
        {
            controller.process(item);
        }
    }
}