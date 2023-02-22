namespace KSP_34_3z_3;

public enum Operator
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public static class OperatorExtensions
{
    public static char ToChar(this Operator op)
        => op switch
        {
            Operator.Addition => '+',
            Operator.Subtraction => '-',
            Operator.Multiplication => '*',
            Operator.Division => '/',
            _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
        };

    public static Operator ToOperator(this char c)
        => c switch
        {
            '+' => Operator.Addition,
            '-' => Operator.Subtraction,
            '*' => Operator.Multiplication,
            '/' => Operator.Division,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
}