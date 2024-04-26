namespace CalculatorEngine;

public static class Calculator
{
    //preq-ENGINE-3
    public static Result<double> Add(double x, double y) => new(x + y, true, $"{x} + {y}");

    //preq-ENGINE-4
    public static Result<double> Subtract(double x, double y) => new(x - y, true, $"{x} - {y}");

    public static Result<double> Divide(double x, double y) =>
        y == 0 ? 
            new Result<double>(false, $"{x} / {y}", "Cannot divide by zero") : 
            new Result<double>(x / y, true, $"{x} / {y}");

    public static Result<double> Multiply(double x, double y) => new(x * y, true, $"{x} * {y}");

    public static Result<bool> IsEqual(double x, double y) => new(Math.Abs(x - y) < 0.00000001, true, $"{x} == {y}");

    public static Result<double> RaiseToPower(double x, double y) => new(Math.Pow(x, y), true, $"{x}^{y}");

    public static Result<double> LogOfNumber(double a, double b)
    {
        if (a <= 0) return new Result<double>(false, $"{a} Log {b}", "Log is zero");
        
        return b == 0 ? 
            new Result<double>(false, $"{a} Log {b}", "Base is zero") : 
            new Result<double>(Math.Log(a,b),true, $"{a} Log {b}", "");
    }

    public static Result<double> RootOfNumber(double a, double b)
    {
        if (b <= 0)
            return new Result<double>(false, $"{b} Root of {a}", "Root index must be positive");

        return new Result<double>(Math.Pow(a, 1.0 / b), true, $"{b} Root of {a}");
    }

    public static Result<double> Factorial(double a)
    {
       
        double result = 1;
        for (int i = 2; i <= (int)a; i++)
        {
            result *= i;
        }

        return new Result<double>(result, true, $"{a}!");
    }

    public static Result<double> Sine(double a) => new(Math.Sin(a), true, $"sin({a})");

    public static Result<double> Cosine(double a) => new(Math.Cos(a), true, $"cos({a})");

    public static Result<double> Tangent(double a) => new(Math.Tan(a), true, $"tan({a})");

    public static Result<double> Reciprocal(double a) =>
        a == 0 ?
            new Result<double>(false, $"1/{a}", "Cannot divide by zero") :
            new Result<double>(1 / a, true, $"1/{a}");
}