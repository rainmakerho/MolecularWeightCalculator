# Molecular Mass Weight Calculator

This is a C# library for calculating the molecular mass of chemical compounds.
It allows you to input a chemical formula and computes the total molecular weight by summing up the atomic weights of the constituent elements.

## Features

-   Calculate the molecular weight of chemical compounds.
-   Support for standard atomic weights of elements.
-   Simple and intuitive DLL for integration into your projects.

## Installation

You can install the Molecular Mass Calculator library via NuGet Package Manager Console:

```bash
NuGet\Install-Package MolecularWeightCalculator
```

## Usage

Here's how you can use the library to calculate the molecular weight of a chemical compound:

```csharp
var molecularMath = new MolecularMath();
string exp1 = "CO2";
DisplayExpressionInfo(exp1);


string exp2 = "CaCO3";
DisplayExpressionInfo(exp2);

string exp3 = "CO2 / CaCO3";
DisplayExpressionInfo(exp3);

string exp4 = "C2H2 +2.5 * O2";
DisplayExpressionInfo(exp4);


string exp5 = "2*CO2/C2H2";
DisplayExpressionInfo(exp5);

string exp6 = "1*2*3*4";
DisplayExpressionInfo(exp6);

string exp7 = "CaCO3 * A2 + B3";
DisplayExpressionInfo(exp7);
//KeyNotFoundException: 'A' was not present in the Periodic Table

//calculate only contain C (Carbon)

Console.WriteLine($"===== calculate only contain C (Carbon) =====");
string filterMoleculars = "C";
string exp8 = "CaO + CO2";
DisplayExpressionInfo(exp8, filterMoleculars);

string exp9 = "C2H2 +2.5*O2";
DisplayExpressionInfo(exp9, filterMoleculars);

string expA = "2*CO2 + H2O";
DisplayExpressionInfo(expA, filterMoleculars);

// Date function test
Console.WriteLine($"===== Date function test =====");
string expB = "Days('2023-01-01', '2023/01/10') + 1";
DisplayExpressionInfo2(expB);

string expC = "Days('2023-01-01 10:10:10', '2023/01/10') + 1";
DisplayExpressionInfo2(expC);

string expD = "Pow(Days('2023-01-01', '2023/01/10'),2)";
DisplayExpressionInfo2(expD);

string expE = "Pow(Days('2023-01-10', '2023/01/4') + 1,3)";
DisplayExpressionInfo2(expE);


Console.WriteLine($"Press any key to exit.....");
Console.ReadKey();

void DisplayExpressionInfo(string expression, string filterMoleculars="")
{
    Console.WriteLine($"==={expression}, filter Moleculars:({filterMoleculars}){new String('=', 10)}");
    string[] filterMolecularsArray = filterMoleculars.Split(',', StringSplitOptions.RemoveEmptyEntries);
    try
    {
        var parameters = molecularMath.GetParameters(expression);
        Console.WriteLine($"==={expression}:Parameters({parameters.Count}),{new String('=', 10)}");
        foreach (var parameter in parameters)
        {
            Console.WriteLine(parameter);
        }
        Console.WriteLine(new String('=', 30));
        var result = molecularMath.ComputeMass(expression, filterMolecularsArray);
        Console.WriteLine($"{expression}=>{result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    
    Console.WriteLine(new String('*', 50));
}

void DisplayExpressionInfo2(string expression)
{
    Console.WriteLine($"==={expression}{new String('=', 10)}");
    try
    {
        if (molecularMath == null)
        {
            Console.WriteLine("Error: molecularMath service is not available.");
            return;
        }
        var parameters = molecularMath.GetParameters(expression);
        Console.WriteLine($"==={expression}:Parameters({parameters.Count}),{new String('=', 10)}");
        foreach (var parameter in parameters)
        {
            Console.WriteLine(parameter);
        }
        Console.WriteLine(new String('=', 30));
        var result = molecularMath.Evaluate(expression);
        Console.WriteLine($"{expression}=>{result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }

    Console.WriteLine(new String('*', 50));
}

```
Execute Result:
```
===CO2, filter Moleculars:()==========
===CO2:Parameters(1),==========
CO2
==============================
CO2=>44.009
**************************************************
===CaCO3, filter Moleculars:()==========
===CaCO3:Parameters(1),==========
CaCO3
==============================
CaCO3=>100.086
**************************************************
===CO2 / CaCO3, filter Moleculars:()==========
===CO2 / CaCO3:Parameters(2),==========
CO2
CaCO3
==============================
CO2 / CaCO3=>0.43971184781088263
**************************************************
===C2H2 +2.5 * O2, filter Moleculars:()==========
===C2H2 +2.5 * O2:Parameters(2),==========
C2H2
O2
==============================
C2H2 +2.5 * O2=>106.033
**************************************************
===2*CO2/C2H2, filter Moleculars:()==========
===2*CO2/C2H2:Parameters(2),==========
CO2
C2H2
==============================
2*CO2/C2H2=>3.3803671556955224
**************************************************
===1*2*3*4, filter Moleculars:()==========
===1*2*3*4:Parameters(0),==========
==============================
1*2*3*4=>24
**************************************************
===CaCO3 * A2 + B3, filter Moleculars:()==========
===CaCO3 * A2 + B3:Parameters(3),==========
CaCO3
A2
B3
==============================
System.Collections.Generic.KeyNotFoundException: 'A' was not present in the Periodic Table
**************************************************
===== calculate only contain C (Carbon) =====
===CaO + CO2, filter Moleculars:(C)==========
===CaO + CO2:Parameters(2),==========
CaO
CO2
==============================
CaO + CO2=>44.009
**************************************************
===C2H2 +2.5*O2, filter Moleculars:(C)==========
===C2H2 +2.5*O2:Parameters(2),==========
C2H2
O2
==============================
C2H2 +2.5*O2=>26.037999999999997
**************************************************
===2*CO2 + H2O, filter Moleculars:(C)==========
===2*CO2 + H2O:Parameters(2),==========
CO2
H2O
==============================
2*CO2 + H2O=>88.018
**************************************************
===== Date function test =====
===Days('2023-01-01', '2023/01/10') + 1==========
===Days('2023-01-01', '2023/01/10') + 1:Parameters(0),==========
==============================
Days('2023-01-01', '2023/01/10') + 1=>-8
**************************************************
===Days('2023-01-01 10:10:10', '2023/01/10') + 1==========
===Days('2023-01-01 10:10:10', '2023/01/10') + 1:Parameters(0),==========
==============================
Days('2023-01-01 10:10:10', '2023/01/10') + 1=>-7.5762731481481485
**************************************************
===Pow(Days('2023-01-01', '2023/01/10'),2)==========
===Pow(Days('2023-01-01', '2023/01/10'),2):Parameters(0),==========
==============================
Pow(Days('2023-01-01', '2023/01/10'),2)=>81
**************************************************
===Pow(Days('2023-01-10', '2023/01/4') + 1,3)==========
===Pow(Days('2023-01-10', '2023/01/4') + 1,3):Parameters(0),==========
==============================
Pow(Days('2023-01-10', '2023/01/4') + 1,3)=>343
**************************************************
```

## ChangeLog

### 1.0.2

1. fix: change ComputeMass method return type from double to object

### 1.0.3

1. change Periodic Table from https://iupac.org/what-we-do/periodic-table-of-elements/

### 1.0.4

1. Add filtering to only calculate the molecular weight of compounds with certain chemical elements, such as only contain C (Carbon)

### 1.0.5
1. fix [Provide analytical expressions and obtain parameter information](https://github.com/rainmakerho/MolecularWeightCalculator/issues/1) issue
2. Add MolecularWeightCalculator.Tests.csproj

### 25.05.01
1. [是否可以加入類似Excel提供的Days函式(End Date, Start Day), 計算兩個日期之間的天數? #3](https://github.com/rainmakerho/MolecularWeightCalculator/issues/3)


## Checkmarx Report
[Checkmarx Report](checkmarxReport.pdf):None High, medium and low risk

## Contributing

Contributions are welcome!
If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
