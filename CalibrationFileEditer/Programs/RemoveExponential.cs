using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalibrationFileEditer
{
    public class RemoveExponentials : IPrograms
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
                        file = file.Replace(exponentials[i].Value.ToString(), "0");
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
    }
}