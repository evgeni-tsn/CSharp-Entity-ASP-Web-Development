using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _01.CustomLINQExtensionMethods
{
    public static class Extension
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(element => !predicate(element)).ToList();
        }

        public static TSelector Max<TSource, TSelector>(this IEnumerable<TSource> collection,
            Func<TSource, TSelector> criterion) where TSelector : IComparable<TSelector>
        {
            TSelector max = criterion(collection.First());

            foreach (var item in collection.Where(item => max.CompareTo(criterion(item)) < 0))
            {
                max = criterion(item);
            }
            return max;
        }

        public static TSelector Min<TSource, TSelector>(this IEnumerable<TSource> collection,
            Func<TSource, TSelector> criterion) where TSelector : IComparable<TSelector>
        {
            TSelector min = criterion(collection.First());

            foreach (var item in collection.Where(item => min.CompareTo(criterion(item)) < 0))
            {
                min = criterion(item);
            }
            return min;
        }

        public static TSource MaxStudent<TSource, TSelector>(this IEnumerable<TSource> collection,
            Func<TSource, TSelector> criterion) where TSelector : IComparable<TSelector>
        {
            return collection.OrderByDescending(criterion).First();
        }

        public static TSource MinStudent<TSource, TSelector>(
            this IEnumerable<TSource> collection,
            Func<TSource, TSelector> criterion) where TSelector : IComparable<TSelector>
        {
            return collection.OrderBy(criterion).First();
        }
    }
}