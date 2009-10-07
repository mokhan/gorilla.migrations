using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using simple.migrations;

namespace tests
{
    public class RunMigrationsCommandSpecs
    {
        public class concern : observations_for_a_sut_with_a_contract<ConsoleCommand, RunMigrationsCommand>
        {
        }

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

            because b = () => { result = sut.can_handle(proper_arguments); };

            it should_recognize_the_arguments = () => result.should_be_true();

            static ConsoleArguments proper_arguments;
            static bool result;
        }

        public class when_unknown_arguments_are_specified : concern
        {
            context c = () => { unknown_arguments = new[] {""}; };

            because b = () => { result = sut.can_handle(unknown_arguments); };

            it should_not_recognize_the_arguments_to_run_the_database_migrations = () => result.should_be_false();

            static ConsoleArguments unknown_arguments;

            static bool result;
        }
    }
}