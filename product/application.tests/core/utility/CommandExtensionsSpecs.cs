using System;
using System.Threading;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using gorilla.migrations;
using gorilla.migrations.utility;

namespace tests.core.utility
{
    public class CommandExtensionsSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (CommandExtensions))]
        public class when_chaining_a_set_of_commands : concern
        {
            context c = () =>
            {
                first_command = new TestCommand();
                second_command = new TestCommand.SubCommand();
            };

            because b = () =>
            {
                first_command.then(second_command).run();
            };

            it should_run_each_command_in_the_correct_order = () =>
            {
                first_command.ran_first().should_be_true();
                second_command.ran().should_be_true();
            };

            static TestCommand first_command;
            static TestCommand.SubCommand second_command;
        }
    }

    class TestCommand : Command
    {
        public TestCommand()
        {
            first_has_run = DateTime.MinValue;
            second_has_run = DateTime.MinValue;
        }

        public void run()
        {
            first_has_run = DateTime.Now;
            Thread.Sleep(10);
        }

        public bool ran_first()
        {
            return first_has_run < second_has_run;
        }

        static DateTime second_has_run;
        static DateTime first_has_run;

        public class SubCommand : Command
        {
            public void run()
            {
                second_has_run = DateTime.Now;
            }

            public bool ran()
            {
                return !second_has_run.Equals(DateTime.MinValue);
            }
        }
    }
}