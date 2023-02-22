namespace KSP_34_3z_3;

internal class Input
{
    public readonly int N, M;
    public readonly string X;
    public readonly IEnumerable<Equation> ToSolve;
    public readonly ISet<string> Known;
    public readonly IEnumerable<Equation> Equations;

    private Input(int n, int m, string x, ISet<string> known, IEnumerable<Equation> equations)
    {
        this.N = n;
        this.M = m;
        this.X = x;
        this.Known = known;
        this.Equations = equations;
        this.ToSolve = this.Equations.Where(e => e.Left == x);
    }

    public static Input ReadInput()
    {
        var firstLn = Console.ReadLine()!.Split(' ');
        
        var n = int.Parse(firstLn[0]);
        var m = int.Parse(firstLn[1]);
        var x = firstLn[2];

        var known = Console.ReadLine()!.Split(' ').ToHashSet();
        var equations = LambdaExtensions.RepeatTimesApply(i => Equation.Parse(Console.ReadLine()!), m);

        return new Input(n, m, x, known, equations);
    }
}