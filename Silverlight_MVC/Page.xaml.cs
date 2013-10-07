using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DietCalculator.Core;

namespace Silverlight_MVC
{
	public partial class Page : UserControl
	{
		public Page()
		{
			InitializeComponent();
            IDietCalculatorModel model = new DietCalculatorModel();
            IDietCalculatorController controller = new DietCalculatorController( calculatorView_v1, model );

            IDietCalculatorModel model_v2 = new DietCalculatorModel_v2();
            this.DataContext = model_v2;
            IDietCalculatorController controller_v2 = new DietCalculatorController_v2( calculatorView_v2, model_v2 );
		}
	}
}
