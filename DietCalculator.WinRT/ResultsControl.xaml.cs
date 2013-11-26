using DietCalculator.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DietCalculator.WinRT
{
    public sealed partial class ResultsControl : UserControl
    {


        public ResultsControl()
        {
            this.InitializeComponent();
        }

        public ResultsControl(IDietCalculatorModel model) : this()
        {
            this.DataContext = model;       
        }

    }
}
