using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanDate.Extensions
{
    internal static partial class LinqEx
    {
        /// <summary>
        /// Apply Where statement only if condition is met
        /// </summary>
        /// <param name="source">The source to apply the Where statement on</param>
        /// <param name="condition">The external condition to determine whether the Where statement should be applied</param>
        /// <param name="predicate">The Where statement to apply to the source if condition met</param>
        /// <typeparam name="TSource">The type of the list</typeparam>
        /// <returns>A filtered list if the Where statement was applied, otherwise returns the original list</returns>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }
    }
}
