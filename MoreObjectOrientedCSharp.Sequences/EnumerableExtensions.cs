using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreObjectOrientedCSharp.Sequences
{
    public static class EnumerableExtensions
    {
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
            where T : class
            where TKey : IComparable<TKey> =>
            sequence
                .Select(obj => Tuple.Create(obj, criterion(obj)))
                .Aggregate((Tuple<T, TKey>) null,
                    (best, current) =>
                        best == null || current.Item2.CompareTo(best.Item2) < 0 ? current : best)
                .Item1;
    }
}