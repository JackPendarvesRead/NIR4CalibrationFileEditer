using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalibrationFileEditer
{
    public class RemoveExponentials : IModule
    {
        public string GetName()
        {
            var name = "Find and delete exponentials" ;
            return (name);
        }        

        public void RunProgram(DataProvider provider)
        {
            var file = provider.GetData();
            var regex = new RegexSearches();
            var findExponential = new Regex(regex.findExponential);

            try
            {
                var exponentials = findExponential.Matches(file);
                if (exponentials.Count > 0)
                {
                    Console.WriteLine($"Removing {exponentials.Count} exponentials found in file...");
                    for (var i = 0; i < exponentials.Count; i++)
                    {
                        Console.WriteLine(exponentials[i].Value.ToString());
                        string number = exponentials[i].Value.ToString();
                        file = file.Replace(number, ConvertExponential(number));
                    }
                    provider.SetData(file);
                    Console.WriteLine("Exponentials removed.");
                }
                else
                {
                    Console.WriteLine("There are no exponentials in this file.");
                }                
            }
            catch
            {
                Console.WriteLine("Error.");
            }            
        }

        private string ConvertExponential(string x)
        {
            var regex = new Regex("(-?)([0-9])\\.([0-9]+)E-([0-9]{2})");
            var match = regex.Match(x);

            int numberOfZeroes = Int32.Parse(match.Groups[4].Value);
            var sb = new StringBuilder();
            sb.Append(match.Groups[1].Value);
            sb.Append("0.");
            if (numberOfZeroes > 0)
            {
                for (var i = 0; i < numberOfZeroes - 1; i++)
                {
                    sb.Append("0");
                }
            }
            sb.Append(match.Groups[2].Value);
            sb.Append(match.Groups[3].Value);
            return sb.ToString();
        }
    }
}