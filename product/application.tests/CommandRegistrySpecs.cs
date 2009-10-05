using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using Rhino.Mocks;
using simple.migrations;

namespace tests
{
    public class CommandRegistrySpecs
    {
        public class concern : observations_for_a_sut_with_a_contract<CommandRegistry, ConsoleArgumentsCommandRegistry>
        {
        }

        public class when_looking_up_the_appropriate_command_for_some_console_arguments : concern
        {
            it should_return_the_command_that_can_process_the_request = () => { result.should_be_equal_to(command); };

            context c = () =>
                            {
                                command = an<ConsoleCommand>();
                                command.Stub(x => x.can_handle(arguments)).Return(true);
                            };

            after_the_sut_has_been_created a = () => { sut.register(command); };

            because b = () => { result = controller.sut.command_for(arguments); };

            static readonly string[] arguments = new[] {""};
            static ParameterizedCommand<string[]> result;
            static ConsoleCommand command;
        }

        public class when_attempting_to_find_a_command_that_can_process_a_set_of_arguments_that_is_not_recognized :
            concern
        {
            it should_return_a_command_that_can_inform_the_user_of_the_error =
                () => { result.should_be_an_instance_of<HelpCommand>(); };

            context c = () =>
                            {
                                command = an<ConsoleCommand>();
                                command.Stub(x => x.can_handle(arguments)).Return(false);
                            };

            after_the_sut_has_been_created a = () => { sut.register(command); };

            because b = () => { result = controller.sut.command_for(arguments); };

            static readonly string[] arguments = new[] {""};
            static ParameterizedCommand<string[]> result;
            static ConsoleCommand command;
        }
    }
}