

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
}).AddTransient<MolecularMath>();

var serviceProvider = services.BuildServiceProvider();

var logger = serviceProvider.GetService<ILogger<Program>>();
logger.LogInformation("Start App");
var molecularMath =  serviceProvider.GetService<MolecularMath>();
string exp1 = "CO2";
double exp1Result = molecularMath.ComputeMass(exp1);
Console.WriteLine($"{exp1}=>{exp1Result}");
Console.WriteLine(new String('*', 29));

string exp2 = "CaCO3";
double exp2Result = molecularMath.ComputeMass(exp2);
Console.WriteLine($"{exp2}=>{exp2Result}");
Console.WriteLine(new String('*', 29));

string exp3 = "CO2 / CaCO3";
double exp3Result = molecularMath.ComputeMass(exp3);
Console.WriteLine($"{exp3}=>{exp3Result}");
Console.WriteLine(new String('*', 29));

string exp4 = "C2H2 +2.5 * O2";
double exp4Result = molecularMath.ComputeMass(exp4);
Console.WriteLine($"{exp4}=>{exp4Result}");
Console.WriteLine(new String('*', 29));


string exp5 = "2*CO2/C2H2";
double exp5Result = molecularMath.ComputeMass(exp5);
Console.WriteLine($"{exp4}=>{exp5Result}");
Console.WriteLine(new String('*', 29));



Console.WriteLine($"Press any key to exit.....");
Console.ReadKey();