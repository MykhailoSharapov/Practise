// <copyright file="MyLINQExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Practise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// MyLinqExtensions.
    /// </summary>
    public static class MyLINQExtensions
    {
        /// <summary>
        /// thenBy funk.
        /// </summary>
        /// <typeparam name="T">some generic.</typeparam>
        /// <param name="orderedCollection">some collection.</param>
        /// <param name="expression">lamda expression.</param>
        /// <returns>Ienumerable.</returns>
        public static IEnumerable<T> ThenBy<T>(this IOrderedEnumerable<T> orderedCollection, Func<T, bool> expression)
        {
            return orderedCollection.ThenBy(expression);
        }

        /// <summary>
        /// thenByDictinct funk.
        /// </summary>
        /// <typeparam name="T">some generic.</typeparam>
        /// <param name="orderedCollection">some collection.</param>
        /// <param name="expression">lamda expression.</param>
        /// <returns>Ienumerable.</returns>
        public static IEnumerable<T> ThenByDescending<T>(this IOrderedEnumerable<T> orderedCollection, Func<T, bool> expression)
        {
            return orderedCollection.ThenByDescending(expression);
        }

        /// <summary>
        /// My join funk.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <typeparam name="TU">U.</typeparam>
        /// <typeparam name="TK">K.</typeparam>
        /// <typeparam name="TV">V.</typeparam>
        /// <param name="outer">Out.</param>
        /// <param name="inner">inner.</param>
        /// <param name="outerKeySelector">outkey.</param>
        /// <param name="innerKeySelector">innerKey.</param>
        /// <param name="resultSelector">result.</param>
        /// <returns>Ienumerable.</returns>
        public static IEnumerable<T> Join<T, TU, TK, TV>(this IEnumerable<T> outer, IEnumerable<TU> inner, Func<T, TK> outerKeySelector, Func<TU, TK> innerKeySelector, Func<T, TU, TV> resultSelector)
        {
            return outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector);
        }
    }
}
