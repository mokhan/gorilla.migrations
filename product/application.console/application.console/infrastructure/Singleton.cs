using System;

namespace gorilla.migrations.console.infrastructure
{
    public class Singleton : Scope
    {
        Func<object> cached_factory;

        public T apply_to<T>(Func<T> factory)
        {
            if (null == cached_factory)
            {
                cached_factory = factory.memoize().as_anonymous();
            }
            return (T) cached_factory();
        }
    }

    static public class FuncExtensions
    {
        static readonly object mutex = new object();

        static public Func<T> memoize<T>(this Func<T> factory)
        {
            var item = default(T);

            return () =>
            {
                if (null == item)
                {
                    lock (mutex)
                    {
                        if (null == item)
                            item = factory();
                    }
                }
                return item;
            };
        }

        static public Func<object> as_anonymous<T>(this Func<T> factory)
        {
            return () => factory();
        }
    }
}