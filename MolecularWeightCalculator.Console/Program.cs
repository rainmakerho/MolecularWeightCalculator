

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
var exp1Result = molecularMath.ComputeMass(exp1);
Console.WriteLine($"{exp1}=>{exp1Result}");
Console.WriteLine(new String('*', 29));

string exp2 = "CaCO3";
var exp2Result = molecularMath.ComputeMass(exp2);
Console.WriteLine($"{exp2}=>{exp2Result}");
Console.WriteLine(new String('*', 29));

string exp3 = "CO2 / CaCO3";
var exp3Result = molecularMath.ComputeMass(exp3);
Console.WriteLine($"{exp3}=>{exp3Result}");
Console.WriteLine(new String('*', 29));

string exp4 = "C2H2 +2.5 * O2";
var exp4Result = molecularMath.ComputeMass(exp4);
Console.WriteLine($"{exp4}=>{exp4Result}");
Console.WriteLine(new String('*', 29));


string exp5 = "2*CO2/C2H2";
var exp5Result = molecularMath.ComputeMass(exp5);
Console.WriteLine($"{exp5}=>{exp5Result}");
Console.WriteLine(new String('*', 29));

string exp6 = "1*2*3*4";
var exp6Result = molecularMath.ComputeMass(exp6);
Console.WriteLine($"{exp6}=>{exp6Result}");
Console.WriteLine(new String('*', 29));

string exp7 = "CaCO3 * A2 + B3";
var exp7Result = molecularMath.ComputeMass(exp7);
//KeyNotFoundException: 'A' was not present in the Periodic Table
Console.WriteLine($"{exp7}=>{exp7Result}");
Console.WriteLine(new String('*', 29));

Console.WriteLine($"Press any key to exit.....");
Console.ReadKey();