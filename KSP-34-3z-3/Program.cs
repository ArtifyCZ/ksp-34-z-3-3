using System.Collections.Immutable;
using KSP_34_3z_3;

var input = Input.ReadInput();

var known = input.Known;

var equations = input.Equations.Where(x => x.Left != x.RightA && x.Left != x.RightB).GroupBy(x => x.Left)
    .Where(x => !known.Contains(x.Key))
    .Select(x => new { x.Key, Value = x.ToImmutableList() })
    .ToDictionary(x => x.Key, x => x.Value);

var eqByRightFn = () =>
{
    var eqs = new Dictionary<string, List<Equation>>();

    foreach (var equation in equations.SelectMany(x => x.Value))
    {
        if (!eqs.ContainsKey(equation.RightA))
            eqs[equation.RightA] = new List<Equation>();
        eqs[equation.RightA].Add(equation);
            
        if (!eqs.ContainsKey(equation.RightB))
            eqs[equation.RightB] = new List<Equation>();
        eqs[equation.RightB].Add(equation);
    }

    return eqs;
};

var eqByRight = eqByRightFn();

var withKnown = equations.SelectMany(x => x.Value)
    .Where(x => known.Contains(x.RightA) && known.Contains(x.RightB))
    .ToImmutableList();

var abc = () =>
{
    var ways = new Dictionary<string, ImmutableList<Equation>>();
    
    var xdc = input.Known;
    
    var xax = new HashSet<string>();

    var knownVars = new HashSet<string>();
    foreach (var x in input.Known)
    {
        knownVars.Add(x);
    }

    var eqs = new Queue<Equation>();
    
    foreach (var equation in withKnown)
    {
        if(xax.Contains(equation.Left))
            continue;

        xax.Add(equation.Left);
        eqs.Enqueue(equation);
    }

    while (0 < eqs.Count)
    {
        var eq = eqs.Dequeue();
        
        if(xdc.Contains(eq.Left))
            continue;

        if (eq.Left == input.X)
        {
        }

        if (eq.Left != input.X && !eqByRight.ContainsKey(eq.Left))
        {
            continue;
        }
        
        if (!xdc.Contains(eq.RightA) || !xdc.Contains(eq.RightB))
        {
            eqs.Enqueue(eq);
            continue;
        }

        if(eqByRight.ContainsKey(eq.Left))
        {
            foreach (var equation in eqByRight[eq.Left].Where(equation => !xdc.Contains(equation.Left)))
            {
                eqs.Enqueue(equation);
            }
        }
        
        var leftWay = knownVars.Contains(eq.RightA)? Array.Empty<Equation>().ToImmutableList() : ways[eq.RightA];
        var rightWay = knownVars.Contains(eq.RightB)? Array.Empty<Equation>().ToImmutableList() : ways[eq.RightB];
        
        ways.Add(eq.Left, leftWay.Merge(rightWay).Append(eq).ToImmutableList());
        xdc.Add(eq.Left);

        if (eq.Left == input.X)
        {
            break;
        }
    }

    return ways;
};

var a = abc();

foreach (var eq in a[input.X])
{
    Console.WriteLine(eq.ToString());
}