using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolecularWeightCalculator.Tests;
public class ExpressionParametersTest
{
    private double _paramValue = 6.12;
    [Fact]
    public void Get_Zero_Parameters_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "1+2+3.12";

        // Act
        var parameters = molecularMath.GetParameters(expression);
        var result1 = molecularMath.Evaluate(expression);
        var result2 = molecularMath.Evaluate(expression, new Dictionary<string, object>());
        // Assert
        Assert.Empty(parameters);
        Assert.Equal(result1, result2);
        Assert.Equal(6.12, result1);
    }

    [Fact]
    public void Get_X1_Parameters_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "X1";

        // Act
        var parameters = molecularMath.GetParameters(expression);
        var expressionParameters = parameters.ToDictionary(p => p, p => (object)_paramValue);
        var result = molecularMath.Evaluate(expression, expressionParameters);

        // Assert
        Assert.Single(parameters);
        Assert.Contains(expression, parameters);
        Assert.Equal(_paramValue, result);
    }

    [Fact]
    public void Get_X1_XoX2_Parameters_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "X1+XoX2";

        // Act
        var parameters = molecularMath.GetParameters(expression);
        var expressionParameters = parameters.ToDictionary(p => p, p => (object)_paramValue);
        var result = molecularMath.Evaluate(expression, expressionParameters);

        // Assert
        Assert.Contains("X1", parameters);
        Assert.Contains("XoX2", parameters);
        Assert.Equal(_paramValue  + _paramValue, result);
    }

    [Fact]
    public void Get_X1_CaCo2_aBC_Parameters_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "X1/CaCo_2+aBC";

        // Act
        var parameters = molecularMath.GetParameters(expression);
        var expressionParameters = parameters.ToDictionary(p => p, p => (object)_paramValue);
        var result = molecularMath.Evaluate(expression, expressionParameters);
        // Assert
        Assert.Contains("X1", parameters);
        Assert.Contains("CaCo_2", parameters);
        Assert.Contains("aBC", parameters);
        Assert.Equal(_paramValue / _paramValue + _paramValue, result);
    }

    [Fact]
    public void ShouldThrow_Exception_X1_2X1_Parameters()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "X1/2X1";
        var expectedMessage = "expecting EOF";
        // Act
        var exception = Assert.Throws<NCalc.EvaluationException>(() => molecularMath.GetParameters(expression));
        // Assert
        Assert.Contains(expectedMessage, exception.Message);
    }



}
