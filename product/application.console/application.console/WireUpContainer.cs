using gorilla.migrations.console.infrastructure;

namespace gorilla.migrations.console
{
    class WireUpContainer : Command
    {
        public void run()
        {
            var builder = new SimpleContainerBuilder();
            builder.register(() => new ConsoleApplication(ComponentRegistry.get_a<CommandRegistry>())).as_an<Console>();
            builder.register(() => new ConsoleArgumentsCommandRegistry()).as_an<CommandRegistry>().scoped_as<Singleton>();
            ComponentRegistry.initialize_with(builder.build());
        }
    }
}