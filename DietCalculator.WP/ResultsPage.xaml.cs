using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace DietCalculator.WP
{
    public partial class ResultsPage : PhoneApplicationPage
    {
        public ResultsPage()
        {
            InitializeComponent();

            // Set the Model from the previous page which in this case is MainPage
            this.DataContext = MainPage.CalculatedModel;
        }
    }
}