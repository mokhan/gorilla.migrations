using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using gorilla.migrations;

namespace tests.core
{
    public class ConsoleArgumentsSpecs
    {
        public class concern : observations_for_a_sut_without_a_contract<ConsoleArguments>
        {
            after_the_sut_has_been_created a = () =>
            {
                args = controller.sut;
            };

            static protected ConsoleArguments args;
        }

        public class When_parsing_the_value_for_a_console_argument : concern
        {
            context c = () =>
            {
                arguments = new[] {"-first_param:'c:\\tmp' -second_param:'Server=(local)'"};
            };

            after_the_sut_has_been_created a = () =>
            {
                args.arguments = arguments;
            };

            because b = () =>
            {
                result = args.parse_for("second_param");
            };

            it should_return_the_value_specified = () =>
            {
                result.should_be_equal_to("Server=(local)");
            };

            static string result;
            static string[] arguments;
        }
    }
}