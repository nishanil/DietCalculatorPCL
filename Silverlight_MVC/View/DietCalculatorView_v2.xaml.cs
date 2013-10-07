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
	public partial class DietCalculatorView_v2 : UserControl, IDietCalculatorView
	{
        private IDietCalculatorController controller;
        private IDietCalculatorModel model;

	    public bool HipsReadOnly { get; set; }

		public DietCalculatorView_v2()
		{
			InitializeComponent();

            rbSedentary.Tag = LevelOfActivity.Sedentary;
            rbModerate.Tag = LevelOfActivity.Moderate;
            rbActive.Tag = LevelOfActivity.Active;
		}

        public void SetController( IDietCalculatorController controller )
        {
            this.controller = controller;
        }

        public void SetModel( IDietCalculatorModel model )
        {
            rbSedentary.Checked += new RoutedEventHandler( rbSedentary_Checked );
            rbModerate.Checked += new RoutedEventHandler( rbModerate_Checked );
            rbActive.Checked += new RoutedEventHandler( rbActive_Checked );

            this.model = model;

            rbSedentary.Checked += new RoutedEventHandler( rbSedentary_Checked );
            rbModerate.Checked += new RoutedEventHandler( rbModerate_Checked );
            rbActive.Checked += new RoutedEventHandler( rbActive_Checked );
        }

        private void rbSedentary_Checked( object sender, RoutedEventArgs e )
        {
            controller.SetActivity( ( LevelOfActivity )rbSedentary.Tag );
        }

        private void rbModerate_Checked( object sender, RoutedEventArgs e )
        {
            controller.SetActivity( ( LevelOfActivity )rbModerate.Tag );
        }

        private void rbActive_Checked( object sender, RoutedEventArgs e )
        {
            controller.SetActivity( ( LevelOfActivity )rbActive.Tag );
        }
	}
}
