# Molecular Mass Weight Calculator

This is a C# library for calculating the molecular mass of chemical compounds. 
It allows you to input a chemical formula and computes the total molecular weight by summing up the atomic weights of the constituent elements.

## Features

- Calculate the molecular weight of chemical compounds.
- Support for standard atomic weights of elements.
- Simple and intuitive DLL for integration into your projects.

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
var exp1Result = molecularMath.ComputeMass(exp1);
Console.WriteLine($"{exp1}=>{exp1Result}");
//CO2=>44.009

string exp2 = "CaCO3";
var exp2Result = molecularMath.ComputeMass(exp2);
Console.WriteLine($"{exp2}=>{exp2Result}");
//CaCO3=>100.086

string exp3 = "CO2 / CaCO3";
var exp3Result = molecularMath.ComputeMass(exp3);
Console.WriteLine($"{exp3}=>{exp3Result}");
//CO2 / CaCO3=>0.43971184781088263

string exp4 = "C2H2 +2.5 * O2";
var exp4Result = molecularMath.ComputeMass(exp4);
Console.WriteLine($"{exp4}=>{exp4Result}");
//C2H2 +2.5 * O2=>106.033


string exp5 = "2*CO2/C2H2";
var exp5Result = molecularMath.ComputeMass(exp5);
Console.WriteLine($"{exp5}=>{exp5Result}");
//2*CO2/C2H2=>3.3803671556955224

string exp6 = "1*2*3*4";
var exp6Result = molecularMath.ComputeMass(exp6);
Console.WriteLine($"{exp6}=>{exp6Result}");
//1*2*3*4=>24

string exp7 = "CaCO3 * A2 + B3";
//var exp7Result = molecularMath.ComputeMass(exp7);
//Console.WriteLine($"{exp7}=>{exp7Result}");
//KeyNotFoundException: 'A' was not present in the Periodic Table

```

## [ChangeLog](CHANGELOG.md)

## Contributing
Contributions are welcome! 
If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.

## License
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)