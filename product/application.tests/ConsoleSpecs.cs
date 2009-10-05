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
            context c = () => { console_controller = controller.the_dependency<ConsoleController>(); };

            protected static ConsoleController console_controller;
        }

        public class when_running_a_test : concern
        {
            it should_not_blow_up = () => { console_controller.received(x => x.process(console_arguments)); };

            context c = () => { console_arguments = new[] {""}; };

            because b = () => { controller.sut.run_against(console_arguments); };

            static string[] console_arguments;
        }
    }
}