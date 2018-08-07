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
            var exponentials = new Regex(@"-?[0-9]\.[0-9]+E[+-][0-9]{1,2}").Matches(file);
            if (exponentials.Count > 0)
            {
                var convertLogic = new ExponentialStringManipulation.Logic();
                for (var i = 0; i < exponentials.Count; i++)
                {
                    Console.WriteLine(exponentials[i].Value.ToString());
                    string number = exponentials[i].Value.ToString();
                    file = file.Replace(number, convertLogic.ConvertExponential(number));
                }
                provider.SetData(file);
            }
            else
            {
                Console.WriteLine("No exponentials found.");
            }               
        }
    }
}