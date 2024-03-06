

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
var molecularMath =  serviceProvider.GetService<MolecularMath>();
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