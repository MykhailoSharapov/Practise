using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise
{
    public static class MyLINQExtensions
    {
        public static IEnumerable<T> ThenBy<T>(this IOrderedEnumerable<T> orderedCollection, Func<T, bool> expression)
        {
            return orderedCollection.ThenBy(expression);
        }

        public static IEnumerable<T> ThenByDescending<T>(this IOrderedEnumerable<T> orderedCollection, Func<T, bool> expression)
        {
            return orderedCollection.ThenByDescending(expression);
        }
        );
        public static IEnumerable<T> Join<T, U, K, V>(this IEnumerable<T> outer, IEnumerable<U> inner, Func<T, K> outerKeySelector, Func<U, K> innerKeySelector, Func<T, U, V> resultSelector)
        {
            return outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector);
        }
    }
}
