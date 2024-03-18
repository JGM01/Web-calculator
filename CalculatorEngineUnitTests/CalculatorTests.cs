using CalculatorEngine;

namespace CalculatorEngineUnitTests;

[TestFixture]
[TestOf(typeof(Calculator))]
public class CalculatorTests
{

    [Test]
    public void Add_TwoFloatingPointValues_ReturnsSum()
    {
        // Arrange
        const double a = 1.5;
        const double b = 2.75;
        const double expected = 4.25;

        // Act
        var result = Calculator.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }

    [Test]
    public void Subtract_TwoFloatingPointValues_ReturnsDifference()
    {
        // Arrange
        const double a = 5.43;
        const double b = 1.23;
        const double expected = 4.2;

        // Act
        var result = Calculator.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
    
    //Multiply
    [Test]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        // Arrange
        const double a = 55;
        const double b = 23;
        var expected = 1265;

        // Act
        var result = Calculator.Multiply(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }

    [Test]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        // Arrange
        const double a = 100;
        const double b = 33.3;
        const double expected = 3.003003003003;

        // Act
        var result = Calculator.Divide(a, b);

        // Assert
        Assert.That(result.Val, Is.EqualTo(expected).Within(8));
    }
    [Test]
    public void Divide_DivisorIsZero_ReturnsError()
    {
        // Arrange
        const double a = 100;
        const double b = 0;
        var expected = new Result(false,"100 / 0 = ", "Divide by Zero");

        // Act
        var result = Calculator.Divide(a, b);

        // Assert
        Assert.That(result.Err, Is.EqualTo(expected.Err));
    }


    [Test]
    public void Equals_TwoEqualNumbers_ReturnsTrue()
    {
        // Arrange
        const double a = 1234567.23423769124;
        const double b = 1234567.23423769125;
        var expected = true;

        // Act
        var result = Calculator.IsEqual(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void RaiseToPower_TwoNumbers_RaiseFirstNumberToSecond()
    {
        // Arrange
        const double a = 2;
        const double b = 11;
        var expected = Math.Pow(a,b);

        // Act
        var result = Calculator.RaiseToPower(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
    [Test]
    public void LogOfNumber_TwoNumbers_ExponentOfLogAtBase()
    {
        // Arrange
        const double a = 8;
        const double b = 2;
        var expected = Math.Log(a,b);

        // Act
        var result = Calculator.LogOfNumber(a, b);

        // Assert
        Assert.That(result.Val, Is.EqualTo(expected).Within(8));
    }
    [Test]
    public void LogOfNumber_LogIsZero_ThrowLogIsZeroError()
    {
        // Arrange
        const double a = 0;
        const double b = 2;
        var expected = new Result(false, "0 Log 2", "Log is zero");

        // Act
        var result = Calculator.LogOfNumber(a, b);

        // Assert
        Assert.That(result.Err, Is.EqualTo(expected.Err));
    }
    [Test]
    public void LogOfNumber_BaseIsZero_ThrowBaseIsZeroError()
    {
        // Arrange
        const double a = 2;
        const double b = 0;
        var expected = new Result(false, "2 Log 0", "Base is zero");

        // Act
        var result = Calculator.LogOfNumber(a, b);

        // Assert
        Assert.That(result.Err, Is.EqualTo(expected.Err));
    }
    [Test]
    public void RootOfNumber_TwoNumbers_ReturnBthRootOfA()
    {
        // Arrange
        const double a = 8;
        const double b = 3;
        var expected = 2;

        // Act
        var result = Calculator.RootOfNumber(a, b);

        // Assert
        Assert.That(result.Val, Is.EqualTo(expected));
    }
    [Test]
    public void LogOfNumber_RootIsZero_ThrowRootError()
    {
        // Arrange
        const double a = 2;
        const double b = 0;
        var expected = new Result(false, "2 Root 0", "Root is zero");

        // Act
        var result = Calculator.RootOfNumber(a, b);

        // Assert
        Assert.That(result.Err, Is.EqualTo(expected.Err));
    }
    [Test]
    public void Factorial_Number_ReturnsFactorial()
    {
        // Arrange
        const double a = 5;
        var expected = 120;

        // Act
        var result = Calculator.Factorial(a);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
    [Test]
    public void Factorial_Zero_ReturnsOne()
    {
        // Arrange
        const double a = 0;
        var expected = 1;

        // Act
        var result = Calculator.Factorial(a);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
    [Test]
    public void Sine_Number_ReturnSineOfNumber()
    {
        // Arrange
        const double a = 360;
        var expected = 0;

        // Act
        var result = Calculator.Sine(a);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
    [Test]
    public void Cosine_Number_ReturnCosineOfNumber()
    {
        // Arrange
        const double a = 360;
        var expected = 1;

        // Act
        var result = Calculator.Cosine(a);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
    [Test]
    public void Tangent_Number_ReturnTangentOfNumber()
    {
        // Arrange
        const double a = 360;
        var expected = 0;

        // Act
        var result = Calculator.Tangent(a);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
    [Test]
    public void Reciprocal_Number_ReturnReciprocalOfNumber()
    {
        // Arrange
        const double a = 5;
        const double expected = .2;

        // Act
        var result = Calculator.Reciprocal(a);

        // Assert
        Assert.That(result.Val, Is.EqualTo(expected).Within(8));
    }
    [Test]
    public void Reciprocal_Zero_ThrowsZeroDenominatorError()
    {
        // Arrange
        const double a = 0;
        var expected = new Result(false, "", "");

        // Act
        var result = Calculator.Reciprocal(a);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
}