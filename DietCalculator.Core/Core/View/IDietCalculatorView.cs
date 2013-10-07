using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DietCalculator.Core
{
    public interface IDietCalculatorView
    {
        void SetController(IDietCalculatorController controller);

        void SetModel(IDietCalculatorModel model);

        bool HipsReadOnly { get; set; }
    }
}
