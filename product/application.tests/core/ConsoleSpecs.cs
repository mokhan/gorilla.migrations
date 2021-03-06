using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using gorilla.migrations;
using Rhino.Mocks;

namespace tests.core
{
    public class ConsoleSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Console, ConsoleApplication>
        {
            context c = () =>
            {
                command_registry = controller.the_dependency<CommandRegistry>();
            };

            static protected CommandRegistry command_registry;
        }

        public class when_processing_a_new_request : concern
        {
            context c = () =>
            {
                console_arguments = new[] {""};
                correct_command = controller.an<ParameterizedCommand<ConsoleArguments>>();
                command_registry.Stub(x => x.command_for(console_arguments)).Return(correct_command);
            };

            because b = () =>
            {
                controller.sut.run_against(console_arguments);
            };

            it should_run_the_command_that_can_handle_the_request = () =>
            {
                correct_command.received(x => x.run_against(console_arguments));
            };

            static string[] console_arguments;
            static ParameterizedCommand<ConsoleArguments> correct_command;
        }
    }
}