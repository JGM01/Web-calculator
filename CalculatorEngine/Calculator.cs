namespace CalculatorEngine;

public static class Calculator
{
    //preq-ENGINE-3
    public static double Add(double x, double y) => x + y;
    //preq-ENGINE-4
    public static double Subtract(double x, double y) => x - y;

    public static Result Divide(double dividend, double divisor)
    {
        var op = $"{dividend} / {divisor} = ";
        if (divisor == 0)
        {
            var result = new Result(false,"100 / 0 = ", "Divide by Zero");
            return result;
        }
        return new Result(dividend / divisor, true, op, "");
    }

    public static double Multiply(double a, double b) => a * b;

    public static bool IsEqual(double a, double b) => Math.Abs(a - b) < 0.00000001;

    public static double RaiseToPower(double a, double b) => Math.Pow(a, b);

    public static Result LogOfNumber(double d, double d1)
    {
        throw new NotImplementedException();
    }

    public static Result RootOfNumber(double d, double d1)
    {
        throw new NotImplementedException();
    }

    public static double Factorial(double a) => a == 0 ? 1 : a * Factorial(a - 1);

    public static double Sine(double a) => Math.Sin(a);

    public static double Cosine(double a) => Math.Cos(a);

    public static double Tangent(double a) => Math.Tan(a);

    public static Result Reciprocal(double d)
    {
        throw new NotImplementedException();
    }
}