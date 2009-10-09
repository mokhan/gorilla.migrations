using System.Collections.Generic;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace tests.helpers
{
    static public class RhinoStubbingExtensions
    {
        static public IMethodOptions<T> it_will_return<T>(this IMethodOptions<T> options, T item)
        {
            return options.Return(item);
        }

        static public IMethodOptions<IEnumerable<T>> it_will_return<T>(this IMethodOptions<IEnumerable<T>> options, params T[] items)
        {
            return options.Return(new List<T>(items));
        }

        static public IMethodOptions<IEnumerable<T>> it_will_return_nothing<T>(this IMethodOptions<IEnumerable<T>> options)
        {
            return options.it_will_return();
        }

        static public IMethodOptions<R> is_told_to<T, R>(this T item, Function<T, R> action) where T : class
        {
            return item.Stub(action);
        }
    }
}