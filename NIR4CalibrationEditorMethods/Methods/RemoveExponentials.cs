using System.Text;
using System.Text.RegularExpressions;
using log4net;
using System.IO;
using NIR4CalibrationEditorMethods;
using NIR4CalibrationEditorMethods.Domain;

namespace NIR4CalibrationEditorMethods.Methods
{
    public class RemoveExponentials : IMethod
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Run(DataProvider provider)
        {
            var file = provider.GetData();
            var exponentials = RegularExpressions.findExponential.Matches(file);
            if (exponentials.Count > 0)
            {
                Log.Debug($"{exponentials.Count} exponentials found in file:");
                foreach (Match exponential in exponentials)
                {
                    Log.Debug(exponential.Value.ToString());
                    var numberString = exponential.Value.ToString();
                    var converter = new JacksUsefulLibrary.RegularExpressionMethods.ExponentialStringManipulation.ConvertScientificToDecimal();
                    file = file.Replace(numberString, converter.Convert(numberString));
                }
            }
            else
            {
                Log.Debug("No exponentials found.");
            }
            provider.SetData(file);
        }        
    }    
}