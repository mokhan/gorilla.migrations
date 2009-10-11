using gorilla.migrations.console.infrastructure;
using gorilla.migrations.data;
using gorilla.migrations.io;

namespace gorilla.migrations.console
{
    class WireUpContainer : Command
    {
        public void run()
        {
            var builder = new SimpleContainerBuilder();
            builder.register(() => new ConsoleApplication(Ioc.get_a<CommandRegistry>())).as_an<Console>();
            builder.register(() => new ConsoleArgumentsCommandRegistry()).as_an<CommandRegistry>().scoped_as<Singleton>();
            builder.register(() => new RunMigrationsCommand(Ioc.get_a<FileSystem>(), Ioc.get_a<DatabaseGatewayFactory>() )).as_an<ConsoleCommand>();
            builder.register<FileSystem>(() => new WindowsFileSystem());
            builder.register<DatabaseGatewayFactory>(() => new SqlDatabaseGatewayFactory());
            Ioc.initialize_with(builder.build());
        }
    }
}