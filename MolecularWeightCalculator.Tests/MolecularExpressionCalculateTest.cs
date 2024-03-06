namespace MolecularWeightCalculator.Tests;

public class MolecularExpressionCalculateTest
{

    [Fact]
    public void Calculate_CO2_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "CO2";

        // Act
        var result = molecularMath.ComputeMass(expression);

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
        var result = molecularMath.ComputeMass(expression);

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
        var result = molecularMath.ComputeMass(expression);

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
        var result = molecularMath.ComputeMass(expression);

        // Assert
        Assert.Equal(31.998, result);
    }

    [Fact]
    public void CO2_Divison_CaCO3_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "CO2 / CaCO3";

        // Act
        var result = molecularMath.ComputeMass(expression);

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
        var result = molecularMath.ComputeMass(expression);

        // Assert
        Assert.Equal(106.033, result);
    }

    [Fact]
    public void Two_O2_Divison_C2H2_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "2*CO2/C2H2";

        // Act
        var result = molecularMath.ComputeMass(expression);

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
        var result = molecularMath.ComputeMass(expression);

        // Assert
        Assert.Equal(106.033, result);
    }

    [Fact]
    public void One_M_2_M_3_4_ReturnSameValue()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "1*2*3*4";

        // Act
        var result = molecularMath.ComputeMass(expression);

        // Assert
        Assert.Equal(24, result);
    }

    [Fact]
    public void ShouldThrow_KeyNotFoundException_WithCorrectMessage()
    {
        // Arrange
        var molecularMath = new MolecularMath();
        string expression = "CaCO3 * A2 + B3";
        var expectedMessage = "'A' was not present in the Periodic Table";

        // Act
        var exception = Assert.Throws<KeyNotFoundException>(() => molecularMath.ComputeMass(expression));

        // Assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    
}