using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using gorilla.migrations.data;
using gorilla.migrations.io;
using MbUnit.Framework;

namespace tests.io
{
    public class WindowsFileSystemSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<FileSystem, WindowsFileSystem> {}

        [Concern(typeof (WindowsFileSystem))]
        [FixtureCategory("SLOW")]
        public class when_retrieving_all_the_sql_migrations_scripts_from_a_directory : concern
        {
            context c = () =>
            {
                directory = Path.Combine(Environment.CurrentDirectory, "sample_files");
                first_sql_file = Path.Combine(directory, "0001_first_test_file.sql");
                second_sql_file = Path.Combine(directory, "0002_second_sql_file.sql");
                template_file = Path.Combine(directory, "0001_first_test_file.sql.template");
            };

            because b = () =>
            {
                results =controller. sut.all_sql_files_from(directory);
            };

            it should_return_each_sql_file_found_in_the_directory = () =>
            {
                results.Count().should_be_equal_to(2);
                results.should_contain(first_sql_file);
                results.should_contain(second_sql_file);
            };

            it should_not_return_any_other_types_of_files = () =>
            {
                results.should_not_contain(template_file);
            };

            static IEnumerable<SqlFile> results;
            static SqlFile first_sql_file;
            static SqlFile second_sql_file;
            static SqlFile template_file;
            static string directory;
        }
    }
}