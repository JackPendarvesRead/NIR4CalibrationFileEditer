using Aunir.SpectrumAnalysis.FileIO;
using Aunir.SpectrumAnalysis.FileIO.Foss.PLS;
using Aunir.SpectrumAnalysis.Interfaces.Equations;
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
            IEquationFileReader fileReader = new FossEqaPlsEquationFileReader("", "1.0.0.0");
            List<IEquation> eqs = fileReader.ReadFile(new FileStream(fileName, FileMode.Open), out string prodName);
            List<Calibration> calibrations = (from e in eqs select new Calibration(e, fileName)).ToList();
            return calibrations;
        }
    }
}
