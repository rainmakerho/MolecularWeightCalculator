using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MolecularWeightCalculator.Tests;
public class MolecularExpressionFilterCalculateTest
{
    //calculate only contain C (Carbon)
    private string[] _filterMolecularsArray = "C".Split(',', StringSplitOptions.RemoveEmptyEntries);

    [Fact]
    public void Calculate_CO2_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "CO2";

        // Act
        var result = molecularMath.ComputeMass(expression, _filterMolecularsArray);

        // Assert
        Assert.Equal(44.009, result);
    }

    [Fact]
    public void Calculate_CaCO3_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "CaCO3";

        // Act
        var result = molecularMath.ComputeMass(expression, _filterMolecularsArray);

        // Assert
        Assert.Equal(100.086, result);
    }

    [Fact]
    public void Calculate_C2H2_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "C2H2";

        // Act
        var result = molecularMath.ComputeMass(expression, _filterMolecularsArray);

        // Assert
        Assert.Equal(26.037999999999997, result);
    }

    [Fact]
    public void Calculate_O2_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "O2";

        // Act
        var result = molecularMath.ComputeMass(expression, _filterMolecularsArray);

        // Assert
        Assert.Equal(0d, result);
    }

    [Fact]
    public void CO2_Divison_CaCO3_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "CO2 / CaCO3";

        // Act
        var result = molecularMath.ComputeMass(expression, _filterMolecularsArray);

        // Assert
        Assert.Equal(0.43971184781088263, result);
    }

    [Fact]
    public void C2H2_Add_2_5_O2_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "C2H2 +2.5 * O2";

        // Act
        var result = molecularMath.ComputeMass(expression, _filterMolecularsArray);

        // Assert
        Assert.Equal(26.037999999999997, result);
    }

    [Fact]
    public void Two_O2_Divison_C2H2_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "2*CO2/C2H2";

        // Act
        var result = molecularMath.ComputeMass(expression, _filterMolecularsArray);

        // Assert
        Assert.Equal(3.3803671556955224, result);
    }

    [Fact]
    public void Two_CO2_Add_H2O_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "2*CO2 + H2O";

        // Act
        var result = molecularMath.ComputeMass(expression, _filterMolecularsArray);

        // Assert
        Assert.Equal(88.018, result);
    }
}
