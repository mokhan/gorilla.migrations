using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using simple.migrations.Data;

namespace tests.data
{
    public class SqlFileSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<SqlFile>
        {
            after_the_sut_has_been_created a = () =>
            {
                sut.path = @"c:\\tmp\scripts\0099_the_gretzky_script.sql";
            };
        }

        [Concern(typeof (SqlFile))]
        public class when_checking_if_a_migration_script_is_greater_than_a_specific_version : concern
        {
            it should_return_true_when_it_is = () =>
            {
                sut.is_greater_than(98).should_be_true();
            };

            it should_return_false_when_it_is_not = () =>
            {
                sut.is_greater_than(99).should_be_false();
            };
        }
    }
}