using System;
using System.Globalization;

namespace simple.migrations.utility
{
    static public class ConversionExtensions
    {
        static public T convert_to<T>(this object item)
        {
            return (T) Convert.ChangeType(item, typeof (T), CultureInfo.InvariantCulture);
        }
    }
}