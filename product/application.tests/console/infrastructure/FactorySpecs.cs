using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using gorilla.migrations.console.infrastructure;

namespace tests.console.infrastructure
{
    public class FactorySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Scope, Factory> {}

        [Concern(typeof (Factory))]
        public class when_building_a_component_using_a_factory_scope : concern
        {
            it should_return_a_new_instance_each_time = () =>
            {
                Func<object> factory = () => new object();
                var first = controller.sut.apply_to(factory);
                var second = controller.sut.apply_to(factory);
                ReferenceEquals(first, second).should_be_false();
            };
        }
    }
}