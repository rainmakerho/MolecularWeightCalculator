using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolecularWeightCalculator.Tests;


public class DateFunctionTest
{
    private readonly MolecularMath _molecularMath;

    public DateFunctionTest()
    {
        _molecularMath = new MolecularMath();
    }

    [Fact]
    public void DaysFunction_ValidDates_ReturnsCorrectDays()
    {
        // Arrange
        string expression = "Days('2023-01-10', '2023/01/1') + 1";

        // Act
        var parameters = _molecularMath.GetParameters(expression);
        var result = _molecularMath.Evaluate(expression);

        // Assert
        Assert.Equal(10.0, result);
    }

    [Fact]
    public void DaysFunction_InvalidDateFormat_ThrowsException()
    {
        // Arrange
        var expression = "Days('invalid-date', '2023-01-10')";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _molecularMath.Evaluate(expression));
    }

    [Fact]
    public void DaysFunction_IncorrectParameterCount_ThrowsException()
    {
        // Arrange
        var expression = "Days('2023-01-01')";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _molecularMath.Evaluate(expression));
    }

    [Fact]
    public void DaysFunction_ValidDates_ReturnsCorrectDays2()
    {
        // Arrange
        string expression = "Pow(Days('2023-01-10', '2023/01/4') + 1,3)";

        // Act
        var parameters = _molecularMath.GetParameters(expression);
        var result = _molecularMath.Evaluate(expression);

        // Assert
        Assert.Equal(343.0, result);
    }


    [Fact]
    public void DaysTwFunction_ValidDates_ReturnsCorrectDays2()
    {
        // Arrange
        string expression = "DaysTw('111/12/31', '111/1/1') + 1";

        // Act
        var parameters = _molecularMath.GetParameters(expression);
        var result = _molecularMath.Evaluate(expression);

        // Assert
        Assert.Equal(365.0, result);
    }
}