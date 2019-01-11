using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIR4CalibrationEditorMethods.Methods
{
    public interface IMethod
    {
        void Run(Domain.DataProvider dataProvider);
    }
}
