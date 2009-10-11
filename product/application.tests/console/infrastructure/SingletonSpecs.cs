using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using gorilla.migrations.console.infrastructure;

namespace tests.console.infrastructure
{
    public class SingletonSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Scope, Singleton> {}

        [Concern(typeof (Singleton))]
        public class when_retrieving_a_singleton_instance : concern
        {
            it should_return_the_same_instance_each_time = () =>
            {
                Func<TimeStamp> factory = () => new TimeStamp {time = DateTime.Now};
                var first = controller.sut.apply_to(factory);
                var second = controller.sut.apply_to(factory);
                ReferenceEquals(first, second).should_be_true();
            };
        }

        public class TimeStamp
        {
            public DateTime time { get; set; }
        }
    }
}