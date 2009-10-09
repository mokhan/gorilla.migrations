using System;
using System.Collections.Generic;

namespace simple.migrations.utility
{
    static public class IterationExtensions
    {
        static public void each<T>(this IEnumerable<T> items, Action<T> visitor)
        {
            foreach (var item in items) visitor(item);
        }
    }
}