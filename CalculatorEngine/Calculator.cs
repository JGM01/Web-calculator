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

    public static double Multiply(double d, double d1)
    {
        throw new NotImplementedException();
    }

    public static bool IsEqual(double d, double d1)
    {
        throw new NotImplementedException();
    }

    public static double RaiseToPower(double d, double d1)
    {
        throw new NotImplementedException();
    }

    public static Result LogOfNumber(double d, double d1)
    {
        throw new NotImplementedException();
    }

    public static Result RootOfNumber(double d, double d1)
    {
        throw new NotImplementedException();
    }

    public static double Factorial(double d)
    {
        throw new NotImplementedException();
    }

    public static double Sine(double d)
    {
        throw new NotImplementedException();
    }

    public static double Cosine(double d)
    {
        throw new NotImplementedException();
    }

    public static double Tangent(double d)
    {
        throw new NotImplementedException();
    }

    public static Result Reciprocal(double d)
    {
        throw new NotImplementedException();
    }
}