using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using gorilla.migrations.console.infrastructure;

namespace tests.console
{
    public class SimpleContainerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Container, SimpleContainer>
        {
            context c = () =>
            {
                builder = new SimpleContainerBuilder();
            };

            public override Container create_sut()
            {
                return builder.build();
            }

            static protected SimpleContainerBuilder builder;
        }

        [Concern(typeof (SimpleContainer))]
        public class when_registering_an_item_with_the_container : concern
        {
            context c = () =>
            {
                builder.register(() => new Thingy()).as_an<IThingy>().scoped_as<Factory>();
            };

            because b = () =>
            {
                result = controller.sut.get_a<IThingy>();
            };

            it should_return_a_new_instance_each_time_it_is_told_to_create_one = () =>
            {
                result.should_not_be_equal_to(controller.sut.get_a<IThingy>());
            };

            static IThingy result;
        }

        [Concern(typeof (SimpleContainer))]
        public class when_resolving_multiple_implementations_for_a_component : concern
        {
            context c = () =>
            {
                builder.register(() => new Thingy()).as_an<IThingy>();
                builder.register(() => new AnotherThingy()).as_an<IThingy>();
            };

            because b = () =>
            {
                results = controller.sut.get_all<IThingy>();
            };

            it should_return_each_registered_implementation = () =>
            {
                results.should_contain_item_matching(x => x is Thingy);
                results.should_contain_item_matching(x => x is AnotherThingy);
            };

            static IEnumerable<IThingy> results;
        }
    }


    interface IThingy {}

    class Thingy : IThingy {}

    class AnotherThingy : IThingy {}
}