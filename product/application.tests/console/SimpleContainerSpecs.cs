using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using gorilla.migrations.console.infrastructure;
using MbUnit.Framework;

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

        [Concern(typeof (SimpleContainer))]
        public class when_attempting_to_resolve_an_item_from_the_container_that_has_not_been_registered : concern
        {
            because b = () =>
            {
                controller.doing(() => controller.sut.get_a<string>());
            };

            it should_throw_a_meaningful_exception = () =>
            {
                controller.exception_thrown_by_the_sut.should_be_an_instance_of<ComponentResolutionException<string>>();
            };
        }

        [Concern(typeof (SimpleContainer))]
        [Ignore]
        public class when_resolving_an_ienumerable_of_anything : concern
        {
            context c = () =>
            {
                builder.register(() => new Thingy()).as_an<IThingy>();
                builder.register(() => new AnotherThingy()).as_an<IThingy>();
            };

            because b = () =>
            {
                results = controller.sut.get_a<IEnumerable<IThingy>>();
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