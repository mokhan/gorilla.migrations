using System.Data;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using simple.migrations.Data;
using tests.helpers;

namespace tests.data
{
    public class SqlDatabaseGatewaySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<DatabaseGateway, SqlDatabaseGateway>
        {
            context c = () =>
            {
                command_factory = the_dependency<DatabaseCommandFactory>();
                first_script = an<SqlFile>();
                second_script = an<SqlFile>();
                command = an<DatabaseCommand>();

                var table = new DataTable();
                var row = table.NewRow();
                table.Columns.Add("version");
                row["version"] = "0001";
                table.Rows.Add(row);

                command_factory.is_told_to(x => x.create()).it_will_return(command);
                command.is_told_to(x => x.run("select * from migration_scripts")).it_will_return(table);
                first_script.is_told_to(x => x.is_greater_than(1)).it_will_return(false);
                second_script.is_told_to(x => x.is_greater_than(1)).it_will_return(true);
            };

            static protected DatabaseCommandFactory command_factory;
            static protected SqlFile first_script;
            static protected SqlFile second_script;
            static protected DatabaseCommand command;
        }

        [Concern(typeof (SqlDatabaseGateway))]
        public class when_attempting_to_run_a_migration_script_that_has_already_been_run_against_the_database : concern
        {
            because b = () =>
            {
                sut.run(first_script);
            };

            it should_skip_that_script = () =>
            {
                command.never_received(x => x.run(first_script));
            };
        }

        [Concern(typeof (SqlDatabaseGateway))]
        public class when_running_a_bunch_of_migrations_scripts_against_a_database : concern
        {
            because b = () =>
            {
                sut.run(second_script);
            };

            it should_execute_the_sql_from_each_script_against_the_database = () =>
            {
                command.received(x => x.run(second_script));
            };

            it should_close_the_connection_to_the_database_when_finished = () =>
            {
                command.received(x => x.Dispose());
            };
        }
    }
}