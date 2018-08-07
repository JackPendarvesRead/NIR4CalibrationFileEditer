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
            var convertLogic = new ExponentialStringManipulation.Logic();
            var file = provider.GetData();

            try
            {
                var exponentials = new Regex(@"-?[0-9]\.[0-9]+E[+-][0-9]{1,2}").Matches(file);
                if (exponentials.Count > 0)
                {
                    Console.WriteLine($"Removing {exponentials.Count} exponentials found in file...");
                    for (var i = 0; i < exponentials.Count; i++)
                    {
                        Console.WriteLine(exponentials[i].Value.ToString());
                        string number = exponentials[i].Value.ToString();
                        file = file.Replace(number, convertLogic.ConvertExponential(number));
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