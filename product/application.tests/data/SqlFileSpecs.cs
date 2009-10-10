using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using gorilla.migrations.data;

namespace tests.data
{
    public class SqlFileSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<SqlFile>
        {
            after_the_sut_has_been_created a = () =>
            {
                controller.sut.path = @"c:\\tmp\scripts\0099_the_gretzky_script.sql";
            };
        }

        [Concern(typeof (SqlFile))]
        public class when_checking_if_a_migration_script_is_greater_than_a_specific_version : concern
        {
            it should_return_true_when_it_is = () =>
            {
               controller. sut.is_greater_than(98).should_be_true();
            };

            it should_return_false_when_it_is_not = () =>
            {
                controller.sut.is_greater_than(99).should_be_false();
            };
        }

        [Concern(typeof (SqlFile))]
        public class when_comparing_one_migration_file_to_another : concern
        {
            context c = () =>
            {
                first_script = "c:/tmp/0001_blah_blah.sql";
                second_script = "c:/tmp/0002_another_one.sql";
            };

            it should_be_able_to_tell_when_one_file_is_greater_than_the_other = () =>
            {
                second_script.CompareTo(first_script).should_be_greater_than(0);
            };

            it should_be_able_to_tell_when_one_file_is_less_than_the_other = () =>
            {
                first_script.CompareTo(second_script).should_be_less_than(0);
            };

            it should_be_able_to_tell_when_two_files_are_the_same = () =>
            {
                first_script.CompareTo(first_script).should_be_equal_to(0);
            };

            static SqlFile first_script;
            static SqlFile second_script;
        }
    }
}