using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using gorilla.migrations.console.infrastructure;

namespace tests.console
{
    public class SimpleContainerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Container, SimpleContainer> {}

        [Concern(typeof (SimpleContainer))]
        public class when_registering_an_item_with_the_container : concern
        {
            context c = () =>
            {
                builder = new SimpleContainerBuilder();
                builder.register(() => new Thingy()).As<IThingy>().scope<FactoryScope>();
            };

            [Obsolete("use context property to access testing controller")]
            public override Container create_sut()
            {
                return builder.build();
            }

            because b = () =>
            {
                result = controller.sut.get_a<IThingy>();
            };

            it should_return_a_new_instance_each_time_it_is_told_to_create_one = () =>
            {
                result.should_not_be_equal_to(controller.sut.get_a<IThingy>());
            };

            static SimpleContainerBuilder builder;
            static IThingy result;
        }
    }


    class Thingy : IThingy {}

    interface IThingy {}
}