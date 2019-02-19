using WPFCalibrationFileEditor.Model;
using WPFCalibrationFileEditor.Model.PlsxConverter;

namespace WPFCalibrationFileEditor.PlsxConverter.PlsxConverterMethods
{
    public interface IMethod
    {
        void Run(DataProvider dataProvider);
    }
}
