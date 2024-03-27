using CalculatorEngine;

namespace CalculatorEngineUnitTests;

[TestFixture]
[TestOf(typeof(Calculator))]
public class CalculatorTests
{

    
    [Test]
    public void Add_TwoFloatingPointValues_ReturnsSum()
    {
        // preq-UNIT-TEST-2
        
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
        // preq-UNIT-TEST-3
        
        // Arrange
        const double a = 5.43;
        const double b = 1.23;
        const double expected = 4.2;

        // Act
        var result = Calculator.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
    
    [Test]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        // preq-UNIT-TEST-4
        
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
        // preq-UNIT-TEST-5
        
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
        // preq-UNIT-TEST-6
        
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
        // preq-UNIT-TEST-7
        
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
        // preq-UNIT-TEST-8
        
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
        // preq-UNIT-TEST-9
        
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
        // preq-UNIT-TEST-10
        
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
        // preq-UNIT-TEST-11
        
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
        // preq-UNIT-TEST-12
        
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
        // preq-UNIT-TEST-13
        
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
        // preq-UNIT-TEST-14
        
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
        
        // preq-UNIT-TEST-15
        
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
        // preq-UNIT-TEST-16
        
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
        // preq-UNIT-TEST-17
        
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
        // preq-UNIT-TEST-18
        
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
        // preq-UNIT-TEST-19
        
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
        // preq-UNIT-TEST-20
        
        // Arrange
        const double a = 0;
        var expected = new Result(false, "", "");

        // Act
        var result = Calculator.Reciprocal(a);

        // Assert
        Assert.That(result, Is.EqualTo(expected).Within(8));
    }
}