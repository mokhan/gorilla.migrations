using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using simple.migrations;

namespace tests
{
    public class ConsoleSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Console, ConsoleApplication>
        {
            context c = () =>
                            {
                                console_arguments = new[] {""};
                                console_controller = an<ConsoleController>();
                            };

            because b = () => { sut.run_against(console_arguments); };

            it should_not_blow_up = () => { console_controller.received(x => x.process(console_arguments)); };

            static string[] console_arguments;
            static ConsoleController console_controller;
        }
    }
}