namespace KSP_34_3z_3;

public class Equation
{
    public readonly string Left;
    public readonly string RightA;
    public readonly string RightB;
    public readonly Operator Operator;
    
    public Equation(string left, string rightA, string rightB, Operator op)
    {
        this.Left = left;
        this.RightA = rightA;
        this.RightB = rightB;
        this.Operator = op;
    }

    public static Equation Parse(string equation)
    {
        var eq = equation.Split(' ');
        var left = eq[0];
        var rightA = eq[2];
        var rightB = eq[4];
        var op = eq[3][0].ToOperator();

        return new Equation(left, rightA, rightB, op);
    }

    public override string ToString()
        => $"{this.Left} = {this.RightA} {this.Operator.ToChar()} {this.RightB}";
}