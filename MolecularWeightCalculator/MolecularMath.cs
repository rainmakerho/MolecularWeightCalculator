using Microsoft.Extensions.Logging;
using NCalc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MolecularWeightCalculator
{
    public class MolecularMath
    {
        private static IReadOnlyDictionary<string, double> _MolecularWeights
            = new Dictionary<string, double>
               {
                   {"H", 1.00794}, //Hydrogen
                    {"He", 4.002602}, //Helium
                    {"Li", 6.941}, //Lithium
                    {"Be", 9.012182}, //Beryllium
                    {"B", 10.811}, //Boron
                    {"C", 12.0107}, //Carbon
                    {"N", 14.0067}, //Nitrogen
                    {"O", 15.9994}, //Oxygen
                    {"F", 18.9984032}, //Fluorine
                    {"Ne", 20.1797}, //Neon
                    {"Na", 22.98976928}, //Sodium
                    {"Mg", 24.3050}, //Magnesium
                    {"Al", 26.9815386}, //Aluminum
                    {"Si", 28.0855}, //Silicon
                    {"P", 30.973762}, //Phosphorus
                    {"S", 32.065}, //Sulfur
                    {"Cl", 35.453}, //Chlorine
                    {"Ar", 39.948}, //Argon
                    {"K", 39.0983}, //Potassium
                    {"Ca", 40.078}, //Calcium
                    {"Sc", 44.955912}, //Scandium
                    {"Ti", 47.867}, //Titanium
                    {"V", 50.9415}, //Vanadium
                    {"Cr", 51.9961}, //Chromium
                    {"Mn", 54.938045}, //Manganese
                    {"Fe", 55.845}, //Iron
                    {"Co", 58.933195}, //Cobalt
                    {"Ni", 58.6934}, //Nickel
                    {"Cu", 63.546}, //Copper
                    {"Zn", 65.409}, //Zinc
                    {"Ga", 69.723}, //Gallium
                    {"Ge", 72.64}, //Germanium
                    {"As", 74.92160}, //Arsenic
                    {"Se", 78.96}, //Selenium
                    {"Br", 79.904}, //Bromine
                    {"Kr", 83.798}, //Krypton
                    {"Rb", 85.4678}, //Rubidium
                    {"Sr", 87.62}, //Strontium
                    {"Y", 88.90585}, //Yttrium
                    {"Zr", 91.224}, //Zirconium
                    {"Nb", 92.90638}, //Niobium
                    {"Mo", 95.94}, //Molybdenum
                    {"Tc", 98.9063}, //Technetium
                    {"Ru", 101.07}, //Ruthenium
                    {"Rh", 102.90550}, //Rhodium
                    {"Pd", 106.42}, //Palladium
                    {"Ag", 107.8682}, //Silver
                    {"Cd", 112.411}, //Cadmium
                    {"In", 114.818}, //Indium
                    {"Sn", 118.710}, //Tin
                    {"Sb", 121.760}, //Antimony
                    {"Te", 127.60}, //Tellurium
                    {"I", 126.90447}, //Iodine
                    {"Xe", 131.293}, //Xenon
                    {"Cs", 132.9054519}, //Caesium
                    {"Ba", 137.327}, //Barium
                    {"La", 138.90547}, //Lanthanum
                    {"Ce", 140.116}, //Cerium
                    {"Pr", 140.90765}, //Praseodymium
                    {"Nd", 144.242}, //Neodymium
                    {"Pm", 146.9151}, //Promethium
                    {"Sm", 150.36}, //Samarium
                    {"Eu", 151.964}, //Europium
                    {"Gd", 157.25}, //Gadolinium
                    {"Tb", 158.92535}, //Terbium
                    {"Dy", 162.500}, //Dysprosium
                    {"Ho", 164.93032}, //Holmium
                    {"Er", 167.259}, //Erbium
                    {"Tm", 168.93421}, //Thulium
                    {"Yb", 173.04}, //Ytterbium
                    {"Lu", 174.967}, //Lutetium
                    {"Hf", 178.49}, //Hafnium
                    {"Ta", 180.9479}, //Tantalum
                    {"W", 183.84}, //Tungsten
                    {"Re", 186.207}, //Rhenium
                    {"Os", 190.23}, //Osmium
                    {"Ir", 192.217}, //Iridium
                    {"Pt", 195.084}, //Platinum
                    {"Au", 196.966569}, //Gold
                    {"Hg", 200.59}, //Mercury
                    {"Tl", 204.3833}, //Thallium
                    {"Pb", 207.2}, //Lead
                    {"Bi", 208.98040}, //Bismuth
                    {"Po", 208.9824}, //Polonium
                    {"At", 209.9871}, //Astatine
                    {"Rn", 222.0176}, //Radon
                    {"Fr", 223.0197}, //Francium
                    {"Ra", 226.0254}, //Radium
                    {"Ac", 227.0278}, //Actinium
                    {"Th", 232.03806}, //Thorium
                    {"Pa", 231.03588}, //Protactinium
                    {"U", 238.02891}, //Uranium
                    {"Np", 237.0482}, //Neptunium
                    {"Pu", 244.0642}, //Plutonium
                    {"Am", 243.0614}, //Americium
                    {"Cm", 247.0703}, //Curium
                    {"Bk", 247.0703}, //Berkelium
                    {"Cf", 251.0796}, //Californium
                    {"Es", 252.0829}, //Einsteinium
                    {"Fm", 257.0951}, //Fermium
                    {"Md", 258.0986}, //Mendelevium
                    {"No", 259.1009}, //Nobelium
                    {"Lr", 260.1053}, //Lawrencium
                    {"Rf", 261.1087}, //Rutherfordium
                    {"Db", 262.1138}, //Dubnium
                    {"Sg", 263.1182}, //Seaborgium
                    {"Bh", 262.1229}, //Bohrium
                    {"Hs", 265}, //Hassium
                    {"Mt", 266}, //Meitnerium
                    {"Ds", 269}, //Darmstadtium
                    {"Rg", 272}, //Roentgenium
                    {"Uub", 285}, //Ununbium
                    {"Uut", 284}, //Ununtrium
                    {"Uuq", 289}, //Ununquadium
                    {"Uup", 288}, //Ununpentium
                    {"Uuh", 292}, //Ununhexium
                    {"Uuo", 294}, //Ununoctium
                };

        private ILogger<MolecularMath> _logger;

        public MolecularMath()
        {
            
        }
        public MolecularMath(ILogger<MolecularMath> logger)
        {
            _logger = logger;
        }
        public double ComputeMass(string expression)
        {
            _logger?.LogDebug($"start Compute:{expression}");
            var ec = Expression.Compile(expression, false);
            ParameterExtractionVisitor visitor = new ParameterExtractionVisitor();
            ec.Accept(visitor);
            var extractedParameters = visitor.Parameters;

            var e = new Expression(ec);
            foreach (var param in extractedParameters)
            {
                _logger?.LogDebug(param);
                double paramValue = CalcMolecularFormulaMass(param);
                e.Parameters[param] = paramValue;
            }
            double result = (double)e.Evaluate();
            _logger?.LogDebug($"{expression}=>{result}");
            return result;
        }



        double CalcMolecularFormulaMass(string formula)
        {
            // 使用正則表達式匹配元素及其數量
            string pattern = @"([A-Z][a-z]*)(\d*)";
            MatchCollection matches = Regex.Matches(formula, pattern);
            double totalFormulaWeight = 0;
            foreach (Match match in matches)
            {
                string element = match.Groups[1].Value;
                int count = match.Groups[2].Value == "" ? 1 : int.Parse(match.Groups[2].Value);
                var atomicWeight = _MolecularWeights[element];
                var formulaWeight = atomicWeight * count;
                _logger?.LogDebug($"{match.Value}=>{atomicWeight}*{count}={formulaWeight}");
                totalFormulaWeight += formulaWeight;
            }
            _logger?.LogDebug($"{formula}=>{totalFormulaWeight}");
            return totalFormulaWeight;
        }
    }
}
