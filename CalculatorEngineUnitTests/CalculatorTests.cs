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
        var expected = new Result<double>(4.25, true, $"{a} + {b}");

        // Act
        var result = Calculator.Add(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void Subtract_TwoFloatingPointValues_ReturnsDifference()
    {
        // Arrange
        const double a = 5.43;
        const double b = 1.23;
        var expected = new Result<double>(4.2, true, $"{a} - {b}");

        // Act
        var result = Calculator.Subtract(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        // Arrange
        const double a = 55;
        const double b = 23;
        var expected = new Result<double>(1265, true, $"{a} * {b}");

        // Act
        var result = Calculator.Multiply(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        // Arrange
        const double a = 100;
        const double b = 33.3;
        const double expected = 3.003003003003;
        var expectedResult = new Result<double>(expected, true, $"{a} / {b}");

        // Act
        var result = Calculator.Divide(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expectedResult.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expectedResult.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expectedResult.Operation));
        });
    }

    [Test]
    public void Divide_DivisorIsZero_ReturnsError()
    {
        // Arrange
        const double a = 100;
        const double b = 0;
        var expected = new Result<double>(false, $"{a} / {b}", "Cannot divide by zero");

        // Act
        var result = Calculator.Divide(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.ErrorMessage, Is.EqualTo(expected.ErrorMessage));
        });
    }

    [Test]
    public void Equals_TwoUnEqualNumbers_ReturnsFalse()
    {
        // Arrange
        const double a = 1234567.23423760;
        const double b = 1234567.23423769;
        var expected = new Result<bool>(false, true, $"{a} == {b}");

        // Act
        var result = Calculator.IsEqual(a, b);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void RaiseToPower_TwoNumbers_RaiseFirstNumberToSecond()
    {
        // Arrange
        const double a = 2;
        const double b = 11;
        var expected = new Result<double>(Math.Pow(a, b), true, $"{a}^{b}");

        // Act
        var result = Calculator.RaiseToPower(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void LogOfNumber_TwoNumbers_ExponentOfLogAtBase()
    {
        // Arrange
        const double a = 8;
        const double b = 2;
        var expected = new Result<double>(Math.Log(a, b), true, $"{a} Log {b}");

        // Act
        var result = Calculator.LogOfNumber(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void LogOfNumber_LogIsZero_ThrowLogIsZeroError()
    {
        // Arrange
        const double a = 0;
        const double b = 2;
        var expected = new Result<double>(false, $"{a} Log {b}", "Log is zero");

        // Act
        var result = Calculator.LogOfNumber(a, b);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
            Assert.That(result.ErrorMessage, Is.EqualTo(expected.ErrorMessage));
        });
    }

    [Test]
    public void LogOfNumber_BaseIsZero_ThrowBaseIsZeroError()
    {
        // Arrange
        const double a = 2;
        const double b = 0;
        var expected = new Result<double>(false, $"{a} Log {b}", "Base is zero");

        // Act
        var result = Calculator.LogOfNumber(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.ErrorMessage, Is.EqualTo(expected.ErrorMessage));
        });
    }

    [Test]
    public void RootOfNumber_TwoNumbers_ReturnBthRootOfA()
    {
        // Arrange
        const double a = 8;
        const double b = 3;
        const double expected = 2;
        var expectedResult = new Result<double>(expected, true, $"{b} Root of {a}");

        // Act
        var result = Calculator.RootOfNumber(a, b);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expectedResult.Value));
            Assert.That(result.IsSuccess, Is.EqualTo(expectedResult.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expectedResult.Operation));
        });
    }

    [Test]
    public void RootOfNumber_RootIsZero_ThrowRootError()
    {
        // Arrange
        const double a = 2;
        const double b = 0;
        var expected = new Result<double>(false, $"{b} Root of {a}", "Root index must be positive");

        // Act
        var result = Calculator.RootOfNumber(a, b);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.ErrorMessage, Is.EqualTo(expected.ErrorMessage));
        });
    }
    [Test]
    public void Factorial_Number_ReturnsFactorial()
    {
        // Arrange
        const double a = 5;
        var expected = new Result<double>(120, true, $"{a}!");

        // Act
        var result = Calculator.Factorial(a);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void Factorial_Zero_ReturnsOne()
    {
        // Arrange
        const double a = 0;
        var expected = new Result<double>(1, true, $"{a}!");

        // Act
        var result = Calculator.Factorial(a);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void Sine_Number_ReturnSineOfNumber()
    {
        // Arrange
        const double a = 360;
        var expected = new Result<double>(0, true, $"sin({a})");

        // Act
        var result = Calculator.Sine(a);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void Cosine_Number_ReturnCosineOfNumber()
    {
        // Arrange
        const double a = 360;
        var expected = new Result<double>(1, true, $"cos({a})");

        // Act
        var result = Calculator.Cosine(a);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void Tangent_Number_ReturnTangentOfNumber()
    {
        // Arrange
        const double a = 360;
        var expected = new Result<double>(0, true, $"tan({a})");

        // Act
        var result = Calculator.Tangent(a);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expected.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
        });
    }

    [Test]
    public void Reciprocal_Number_ReturnReciprocalOfNumber()
    {
        // Arrange
        const double a = 5;
        const double expected = .2;
        var expectedResult = new Result<double>(expected, true, $"1/{a}");

        // Act
        var result = Calculator.Reciprocal(a);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Value, Is.EqualTo(expectedResult.Value).Within(8));
            Assert.That(result.IsSuccess, Is.EqualTo(expectedResult.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expectedResult.Operation));
        });
    }

    [Test]
    public void Reciprocal_Zero_ThrowsZeroDenominatorError()
    {
        // Arrange
        const double a = 0;
        var expected = new Result<double>(false, $"1/{a}", "Cannot divide by zero");

        // Act
        var result = Calculator.Reciprocal(a);
        
        // Assert
        Assert.Multiple( () =>
        {
            Assert.That(result.IsSuccess, Is.EqualTo(expected.IsSuccess));
            Assert.That(result.Operation, Is.EqualTo(expected.Operation));
            Assert.That(result.ErrorMessage, Is.EqualTo(expected.ErrorMessage));
        });
    }
}