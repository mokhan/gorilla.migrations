using System.Collections.Generic;
using System.Linq;

namespace gorilla.migrations.console.infrastructure
{
    public class SimpleContainer : Container
    {
        readonly IList<Reg> registrations;

        public SimpleContainer(IList<Reg> registrations)
        {
            this.registrations = registrations;
        }

        public T get_a<T>()
        {
            return (T) registrations.First(x => x.is_for<T>()).build();
        }
    }
}