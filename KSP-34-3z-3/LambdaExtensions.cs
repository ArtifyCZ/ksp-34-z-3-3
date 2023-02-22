using System.Collections.Immutable;

namespace KSP_34_3z_3;

public static class LambdaExtensions
{
    public static IEnumerable<T> RepeatTimes<T>(Func<int, T> function, int n)
    {
        for (var i = 0; i < n; i++)
        {
            yield return function(i);
        }
    }

    public static IEnumerable<T> RepeatTimesApply<T>(Func<int, T> function, int n)
        => RepeatTimes(function, n).ToImmutableList();

    public static IEnumerable<T> Merge<T>(this IEnumerable<T> enA, IEnumerable<T> enB)
    {
        var were = new HashSet<T>();

        foreach (var x in enA)
        {
            if(were.Contains(x))
                continue;
            
            were.Add(x);
            yield return x;
        }

        foreach (var x in enB)
        {
            if(were.Contains(x))
                continue;
            
            were.Add(x);
            yield return x;
        }
    }
}