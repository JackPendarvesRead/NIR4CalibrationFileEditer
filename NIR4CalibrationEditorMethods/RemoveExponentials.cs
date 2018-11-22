using System.Text;
using System.Text.RegularExpressions;
using log4net;
using System.IO;
using NIR4CalibrationEditorMethods;

namespace NIR4CalibrationEditorMethods
{
    public class RemoveExponentials
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
                    var number = exponential.Value.ToString();
                    file = file.Replace(number, new ExponentialStringManipulation.ConvertExponentialStringProcess().Convert(number));
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