using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using simple.migrations;

namespace tests
{
    public class RunMigrationsCommandSpecs
    {
        public class when_checking_if_the_proper_console_arguments_are_specified_to_run_the_migrations :
            observations_for_a_sut_with_a_contract<ConsoleCommand, RunMigrationsCommand>
        {
            context c = () =>
                            {
                                proper_arguments =
                                    new[]
                                        {
                                            "-migrations_dir:'c:\\tmp' -connection_string:'Server=(local);Database=test;Integrated Security=True;' -data_provider:'System.Data.SqlClient'"
                                        };
                                unknown_arguments = new[] {""};
                            };

            it should_return_true_when_they_are = () => { sut.can_handle(proper_arguments).should_be_true(); };

            it should_return_false_when_they_are_not = () => { sut.can_handle(unknown_arguments).should_be_false(); };

            static ConsoleArguments proper_arguments;
            static ConsoleArguments unknown_arguments;
        }
    }
}