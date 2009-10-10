using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using gorilla.migrations.data;

namespace tests.data
{
    public class SqlDatabaseGatewayFactorySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<DatabaseGatewayFactory, SqlDatabaseGatewayFactory> {}

        [Concern(typeof (SqlDatabaseGatewayFactory))]
        public class when_creating_a_database_gateway : concern
        {
            context c = () => {};

            because b = () =>
            {
                result = controller.sut.gateway_to("data source=(local);Integrated Security=SSPI;initial catalog=blah;", "System.Data.SqlClient");
            };

            it should_return_a_database_gateway = () =>
            {
                result.should_not_be_null();
            };

            static DatabaseGateway result;
        }
    }
}