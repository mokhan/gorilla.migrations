using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using gorilla.migrations;
using Rhino.Mocks;

namespace tests.core
{
    public class CommandRegistrySpecs
    {
        public class when_commands_are_registered :
            observations_for_a_sut_with_a_contract<CommandRegistry, ConsoleArgumentsCommandRegistry>
        {
            context c = () =>
                            {
                                command = controller.an<ConsoleCommand>();
                                correct_args = controller.an<ConsoleArguments>();
                                command.Stub(x => x.can_handle(correct_args)).Return(true);
                            };

            after_the_sut_has_been_created a = () => { controller.sut.register(command); };

            protected static ConsoleArguments correct_args;
            protected static ConsoleCommand command;
        }

        public class when_looking_up_the_appropriate_command_for_some_console_arguments : when_commands_are_registered
        {
            it should_return_the_command_that_can_process_the_request = () => { result.should_be_equal_to(command); };

            because b = () => { result = controller.sut.command_for(correct_args); };

            static ParameterizedCommand<ConsoleArguments> result;
        }

        public class when_attempting_to_find_a_command_that_can_process_a_set_of_arguments_that_is_not_recognized :
            when_commands_are_registered
        {
            it should_return_a_command_that_can_inform_the_user_of_the_error =
                () => { result.should_be_an_instance_of<HelpCommand>(); };

            because b = () => { result = controller.sut.command_for(unknown_args); };

            static readonly string[] unknown_args = new[] {""};
            static ParameterizedCommand<ConsoleArguments> result;
        }
    }
}