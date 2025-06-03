

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MolecularWeightCalculator;



var services = new ServiceCollection();
services.AddLogging(loggerBuilder =>
{
    loggerBuilder.ClearProviders();
    loggerBuilder.AddConsole()
    .SetMinimumLevel(LogLevel.Debug);
}).AddSingleton<MolecularMath>();

var serviceProvider = services.BuildServiceProvider();

var logger = serviceProvider.GetService<ILogger<Program>>();
logger.LogInformation("Start App");
var molecularMath = serviceProvider.GetService<MolecularMath>();
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

Console.WriteLine($"===== 民國年 DaysTW function test =====");
//民國年 
string expF = "DaysTW('111/12/31', '111/1/1') + 1";
DisplayExpressionInfo2(expF);

string expG = "DaysTW('111/12/31', '111-1-1') + 1";
DisplayExpressionInfo2(expG);

// issue https://github.com/rainmakerho/MolecularWeightCalculator/issues/6
string expH = "(A + B) * C";
var parameters = new Dictionary<string, object>
{
    { "A", "1" },
    { "B", "2" },
    { "C", "3" }
};
var r = molecularMath.Evaluate(expH, parameters);
Console.WriteLine($"{expH} => {r}"); // 36
/*
"1" + "2" results in "12" because string addition concatenates the values.
"12" * "3": NCalc converts both strings to numbers and multiplies them, so 12 * 3 = 36.
*/

var parameters2 = new Dictionary<string, object>
{
    { "A", 1},
    { "B", 2 },
    { "C", "3" }
};
var r2 = molecularMath.Evaluate(expH, parameters2);
Console.WriteLine($"{expH} => {r2}"); // 9

Console.WriteLine($"Press any key to exit.....");
Console.ReadKey();

void DisplayExpressionInfo(string expression, string filterMoleculars = "")
{
    Console.WriteLine($"==={expression}, filter Moleculars:({filterMoleculars}){new String('=', 10)}");
    string[] filterMolecularsArray = filterMoleculars.Split(',', StringSplitOptions.RemoveEmptyEntries);
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