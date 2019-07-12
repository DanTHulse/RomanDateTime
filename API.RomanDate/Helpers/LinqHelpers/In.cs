using System;
using System.Linq;

namespace API.RomanDate.Helpers
{
    public static partial class LinqHelpers
    {
        /// <summary>
        /// Checks if the provided element is present in the list (Reverse of .Contains)
        /// </summary>
        /// <param name="source">The value to check exists</param>
        /// <param name="list">The list to check against</param>
        /// <typeparam name="TSource">The type of the list</typeparam>
        /// <returns>True if the element exists in the list</returns>
        public static bool In<TSource>(this TSource source, params TSource[] list) => list.Contains(source);
    }
}
