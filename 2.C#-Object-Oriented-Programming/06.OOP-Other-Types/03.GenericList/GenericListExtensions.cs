using System;

namespace _03.GenericList
{
    public static class GenericListExtensions
    {
        public static T Minimum<T>(this IGenericList<T> list) where T : IComparable<T>
        {
            var minItem = list[0];
            for (var i = 1; i < list.Size; i++)
            {
                if (list[i].CompareTo(minItem) < 0)
                {
                    minItem = list[i];
                }
            }

            return minItem;
        }

        public static T Maximum<T>(this IGenericList<T> list) where T : IComparable<T>
        {
            var minItem = list[0];
            for (var i = 1; i < list.Size; i++)
            {
                if (list[i].CompareTo(minItem) > 0)
                {
                    minItem = list[i];
                }
            }
            return minItem;
        }
    }
}