using Aunir.SpectrumAnalysis.Interfaces.Equations;
using Aunir.SpectrumAnalysis2.Interfaces.Pls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCalibrationFileEditor.Domain;

namespace WPFCalibrationFileEditor
{
    public class CalibrationLoader
    {
        public List<Calibration> LoadCalibrations(string fileName)
        {
            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Delete))
            {
                IPlsDataReader reader = new Aunir.SpectrumAnalysis2.FossConnector.FossEqaFileReader();
                var eqas = reader.ReadStream(fs);
                return GenerateCalibrations(eqas, fileName).ToList();
            }
        }

        private IEnumerable<Calibration> GenerateCalibrations(IEnumerable<IPlsEquationInformation> eqas, string filename)
        {
            foreach(var eq in eqas)
            {
                yield return new Calibration(eq, filename);
            }
        }
    }
}
