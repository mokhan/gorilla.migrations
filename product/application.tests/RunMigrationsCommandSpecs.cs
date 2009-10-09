using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using simple.migrations;
using simple.migrations.Data;
using simple.migrations.io;
using tests.helpers;

namespace tests
{
    public class RunMigrationsCommandSpecs
    {
        public class concern : observations_for_a_sut_with_a_contract<ConsoleCommand, RunMigrationsCommand>
        {
            context c = () =>
            {
                file_system = the_dependency<FileSystem>();
                database_gateway_factory=the_dependency<DatabaseGatewayFactory>();
            };

            static protected FileSystem file_system;
            static protected DatabaseGatewayFactory database_gateway_factory;
        }

        [Concern(typeof (RunMigrationsCommand))]
        public class when_the_proper_arguments_are_specified_to_run_the_database_migrations : concern
        {
            context c = () =>
            {
                proper_arguments =
                    new[]
                    {
                        "-migrations_dir:'c:\\tmp' -connection_string:'Server=(local);Database=test;Integrated Security=True;' -data_provider:'System.Data.SqlClient'"
                    };
            };

            because b = () =>
            {
                result = sut.can_handle(proper_arguments);
            };

            it should_recognize_the_arguments = () => result.should_be_true();

            static ConsoleArguments proper_arguments;
            static bool result;
        }

        [Concern(typeof (RunMigrationsCommand))]
        public class when_unknown_arguments_are_specified : concern
        {
            context c = () =>
            {
                unknown_arguments = new[] {""};
            };

            because b = () =>
            {
                result = sut.can_handle(unknown_arguments);
            };

            it should_not_recognize_the_arguments_to_run_the_database_migrations = () => result.should_be_false();

            static ConsoleArguments unknown_arguments;

            static bool result;
        }

        [Concern(typeof (RunMigrationsCommand))]
        public class When_the_migrations_command_is_run : concern
        {
            context c = () =>
            {
                old_migration = an<SqlFile>();
                new_migration = an<SqlFile>();
                arguments = an<ConsoleArguments>();
                gateway = an<DatabaseGateway>();

                database_gateway_factory
                    .is_told_to(x => x.gateway_to("blah=blah;","System.Data.SqlClient"))
                    .it_will_return(gateway);
                file_system
                    .is_told_to(x => x.all_sql_files_from("c:\\tmp"))
                    .it_will_return(old_migration, new_migration);

                arguments.is_told_to(x => x.parse_for("migrations_dir")).it_will_return("c:\\tmp");
                arguments.is_told_to(x => x.parse_for("connection_string")).it_will_return("blah=blah;");
                arguments.is_told_to(x => x.parse_for("data_provider")).it_will_return("System.Data.SqlClient");
            };

            because b = () =>
            {
                sut.run_against(arguments);
            };

            it should_run_each_migration_script = () =>
            {
                gateway.received(x => x.run(new_migration));
            };

            static SqlFile new_migration;
            static SqlFile old_migration;
            static ConsoleArguments arguments;
            static DatabaseGateway gateway;
        }
    }
}