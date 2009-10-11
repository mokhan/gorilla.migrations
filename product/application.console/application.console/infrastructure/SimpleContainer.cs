using System.Collections.Generic;
using System.Linq;

namespace gorilla.migrations.console.infrastructure
{
    public class SimpleContainer : Container
    {
        readonly IList<ComponentFactory> registrations;

        public SimpleContainer(IEnumerable<ComponentFactory> registrations)
        {
            this.registrations = registrations.ToList();
        }

        public T get_a<T>()
        {
            var type = typeof (T);
            if (!registrations.Any(x => x.is_for(type))) throw new ComponentResolutionException<T>();

            return (T) registrations.First(x => x.is_for(type)).build();
        }

        public IEnumerable<T> get_all<T>()
        {
            return registrations.Where(x => x.is_for<T>()).Select(x => (T) x.build());
        }
    }
}