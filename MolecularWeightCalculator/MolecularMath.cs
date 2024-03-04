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
        //https://iupac.org/what-we-do/periodic-table-of-elements/
        private static IReadOnlyDictionary<string, double> _MolecularWeights
            = new Dictionary<string, double>
               {
                   {"H", 1.0080}, //Hydrogen
                    {"He", 4.0026}, //Helium
                    {"Li", 6.94}, //Lithium
                    {"Be", 9.0122}, //Beryllium
                    {"B", 10.81}, //Boron
                    {"C", 12.011}, //Carbon
                    {"N", 14.007}, //Nitrogen
                    {"O", 15.999}, //Oxygen
                    {"F", 18.998}, //Fluorine
                    {"Ne", 20.180}, //Neon
                    {"Na", 22.990}, //Sodium
                    {"Mg", 24.305}, //Magnesium
                    {"Al", 26.982}, //Aluminum
                    {"Si", 28.0855}, //Silicon
                    {"P", 30.974}, //Phosphorus
                    {"S", 32.06}, //Sulfur
                    {"Cl", 35.45}, //Chlorine
                    {"Ar", 39.95}, //Argon
                    {"K", 39.098}, //Potassium
                    {"Ca", 40.078}, //Calcium
                    {"Sc", 44.956}, //Scandium
                    {"Ti", 47.867}, //Titanium
                    {"V", 50.942}, //Vanadium
                    {"Cr", 51.996}, //Chromium
                    {"Mn", 54.938}, //Manganese
                    {"Fe", 55.845}, //Iron
                    {"Co", 58.933}, //Cobalt
                    {"Ni", 58.693}, //Nickel
                    {"Cu", 63.546}, //Copper
                    {"Zn", 65.38}, //Zinc
                    {"Ga", 69.723}, //Gallium
                    {"Ge", 72.630}, //Germanium
                    {"As", 74.922}, //Arsenic
                    {"Se", 78.971}, //Selenium
                    {"Br", 79.904}, //Bromine
                    {"Kr", 83.798}, //Krypton
                    {"Rb", 85.468}, //Rubidium
                    {"Sr", 87.62}, //Strontium
                    {"Y", 88.906}, //Yttrium
                    {"Zr", 91.224}, //Zirconium
                    {"Nb", 92.906}, //Niobium
                    {"Mo", 95.95}, //Molybdenum
                    {"Tc", 97}, //Technetium
                    {"Ru", 101.07}, //Ruthenium
                    {"Rh", 102.91}, //Rhodium
                    {"Pd", 106.42}, //Palladium
                    {"Ag", 107.87}, //Silver
                    {"Cd", 112.41}, //Cadmium
                    {"In", 114.82}, //Indium
                    {"Sn", 118.710}, //Tin
                    {"Sb", 121.760}, //Antimony
                    {"Te", 127.60}, //Tellurium
                    {"I", 126.90}, //Iodine
                    {"Xe", 131.29}, //Xenon
                    {"Cs", 132.91}, //Caesium
                    {"Ba", 137.33}, //Barium
                    {"La", 138.91}, //Lanthanum
                    {"Ce", 140.12}, //Cerium
                    {"Pr", 140.91}, //Praseodymium
                    {"Nd", 144.24}, //Neodymium
                    {"Pm", 145}, //Promethium
                    {"Sm", 150.36}, //Samarium
                    {"Eu", 151.96}, //Europium
                    {"Gd", 157.25}, //Gadolinium
                    {"Tb", 158.93}, //Terbium
                    {"Dy", 162.50}, //Dysprosium
                    {"Ho", 164.93}, //Holmium
                    {"Er", 167.26}, //Erbium
                    {"Tm", 168.93}, //Thulium
                    {"Yb", 173.05}, //Ytterbium
                    {"Lu", 174.97}, //Lutetium
                    {"Hf", 178.49}, //Hafnium
                    {"Ta", 180.95}, //Tantalum
                    {"W", 183.84}, //Tungsten
                    {"Re", 186.21}, //Rhenium
                    {"Os", 190.23}, //Osmium
                    {"Ir", 192.22}, //Iridium
                    {"Pt", 195.08}, //Platinum
                    {"Au", 196.97}, //Gold
                    {"Hg", 200.59}, //Mercury
                    {"Tl", 204.38}, //Thallium
                    {"Pb", 207.2}, //Lead
                    {"Bi", 208.98}, //Bismuth
                    {"Po", 209}, //Polonium
                    {"At", 210}, //Astatine
                    {"Rn", 222}, //Radon
                    {"Fr", 223}, //Francium
                    {"Ra", 226}, //Radium
                    {"Ac", 227}, //Actinium
                    {"Th", 232.04}, //Thorium
                    {"Pa", 231.04}, //Protactinium
                    {"U", 238.03}, //Uranium
                    {"Np", 237}, //Neptunium
                    {"Pu", 244}, //Plutonium
                    {"Am", 243}, //Americium
                    {"Cm", 247}, //Curium
                    {"Bk", 247}, //Berkelium
                    {"Cf", 251}, //Californium
                    {"Es", 252}, //Einsteinium
                    {"Fm", 257}, //Fermium
                    {"Md", 258}, //Mendelevium
                    {"No", 259}, //Nobelium
                    {"Lr", 262}, //Lawrencium
                    {"Rf", 267}, //Rutherfordium
                    {"Db", 268}, //Dubnium
                    {"Sg", 269}, //Seaborgium
                    {"Bh", 270}, //Bohrium
                    {"Hs", 269}, //Hassium
                    {"Mt", 277}, //Meitnerium
                    {"Ds", 281}, //Darmstadtium
                    {"Rg", 282}, //Roentgenium
                    {"Cn", 285}, //Copernicium
                    {"Nh", 286}, //Nihonium
                    {"Fl", 290}, //Flerovium
                    {"Mc", 290}, //Moscovium
                    {"Lv", 293}, //Livermorium
                    {"Ts", 294}, //Tennessine
                    {"Og", 294}, //Oganesson
                };

        private ILogger<MolecularMath> _logger;

        public MolecularMath()
        {

        }
        public MolecularMath(ILogger<MolecularMath> logger)
        {
            _logger = logger;
        }
        public object ComputeMass(string expression)
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
            var result = e.Evaluate();
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
                try
                {
                    var atomicWeight = _MolecularWeights[element];
                    var formulaWeight = atomicWeight * count;
                    _logger?.LogDebug($"{match.Value}=>{atomicWeight}*{count}={formulaWeight}");
                    totalFormulaWeight += formulaWeight;
                }
                catch (KeyNotFoundException)
                {
                    throw new KeyNotFoundException($"'{element}' was not present in the Periodic Table");
                }
                catch (Exception)
                {
                    throw;
                }

            }
            _logger?.LogDebug($"{formula}=>{totalFormulaWeight}");
            return totalFormulaWeight;
        }
    }
}
