using System;
using System.Data;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using simple.migrations.Data;
using tests.helpers;

namespace tests.data
{
    public class SqlServerDatabaseGatewaySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<DatabaseGateway, SqlServerDatabaseGateway>
        {
            context c = () =>
            {
                command_factory = the_dependency<DatabaseCommandFactory>();
            };

            static protected DatabaseCommandFactory command_factory;
        }

        [Concern(typeof (SqlServerDatabaseGateway))]
        public class when_attempting_to_run_a_migration_script_that_has_already_been_run_against_the_database : concern
        {
            because b = () => {};

            it should_skip_that_script = () => {};
        }

        [Concern(typeof (SqlServerDatabaseGateway))]
        public class when_running_a_bunch_of_migrations_scripts_against_a_database : concern
        {
            context c = () =>
            {
                sql_file = an<SqlFile>();
                command = an<DatabaseCommand>();

                var table = new DataTable();
                var row = table.NewRow();
                table.Columns.Add("version");
                table.Columns.Add("script_name");
                table.Columns.Add("run_on");
                row["version"] = "0001";
                row["script_name"] = "0001_hello_world.sql";
                row["run_on"] = DateTime.Now;
                table.Rows.Add(row);

                command_factory.is_told_to(x => x.create()).it_will_return(command);
                command.is_told_to(x => x.run("select * from migration_scripts")).it_will_return(table);
                sql_file.is_told_to(x => x.version()).it_will_return(2);
                sql_file.is_told_to(x => x.name()).it_will_return("0002_another_script.sql");
            };

            because b = () =>
            {
                sut.run(sql_file);
            };

            it should_execute_the_sql_from_each_script_against_the_database = () =>
            {
                command.received(x => x.run(sql_file));
            };

            it should_close_the_connection_to_the_database_when_finished = () =>
            {
                command.received(x => x.Dispose());
            };

            static SqlFile sql_file;
            static DatabaseCommand command;
        }
    }
}