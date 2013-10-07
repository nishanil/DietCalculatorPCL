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
    public partial class DietCalculatorView_v1 : UserControl, IDietCalculatorView
    {
        private IDietCalculatorController controller;
        private IDietCalculatorModel model;

        public DietCalculatorView_v1()
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
            model.IdealWeightChanged -= new EventHandler<DietCalculatorEventArgs>( model_IdealWeightChanged );
            model.IdealBMIChanged -= new EventHandler<DietCalculatorEventArgs>( model_IdealBMIChanged );
            model.WaistHipsRatioChanged -= new EventHandler<DietCalculatorEventArgs>( model_WaistHipsRatioChanged );
            model.WaistResultChanged -= new EventHandler<DietCalculatorEventArgs>( model_WaistResultChanged );
            model.WeightResultChanged -= new EventHandler<DietCalculatorEventArgs>( model_WeightResultChanged );
            model.CholesterolRatioChanged -= new EventHandler<DietCalculatorEventArgs>( model_CholesterolRatioChanged );
            model.CholesterolResultChanged -= new EventHandler<DietCalculatorEventArgs>( model_CholesterolResultChanged );
            model.BMIChanged -= new EventHandler<DietCalculatorEventArgs>( model_BMIChanged );
            model.WaistHeightRatioChanged -= new EventHandler<DietCalculatorEventArgs>( model_WaistHeightRatioChanged );
            model.PercentBodyFatChanged -= new EventHandler<DietCalculatorEventArgs>( model_PercentBodyFatChanged );
            model.LeanBodyMassChanged -= new EventHandler<DietCalculatorEventArgs>( model_LeanBodyMassChanged );
            model.CaloriesPerDayChanged -= new EventHandler<DietCalculatorEventArgs>( model_CaloriesPerDayChanged );

            this.model = model;

            model.IdealWeightChanged += new EventHandler<DietCalculatorEventArgs>( model_IdealWeightChanged );
            model.IdealBMIChanged += new EventHandler<DietCalculatorEventArgs>( model_IdealBMIChanged );
            model.WaistHipsRatioChanged += new EventHandler<DietCalculatorEventArgs>( model_WaistHipsRatioChanged );
            model.WaistResultChanged += new EventHandler<DietCalculatorEventArgs>( model_WaistResultChanged );
            model.WeightResultChanged += new EventHandler<DietCalculatorEventArgs>( model_WeightResultChanged );
            model.CholesterolRatioChanged += new EventHandler<DietCalculatorEventArgs>( model_CholesterolRatioChanged );
            model.CholesterolResultChanged += new EventHandler<DietCalculatorEventArgs>( model_CholesterolResultChanged );
            model.BMIChanged += new EventHandler<DietCalculatorEventArgs>( model_BMIChanged );
            model.WaistHeightRatioChanged += new EventHandler<DietCalculatorEventArgs>( model_WaistHeightRatioChanged );
            model.PercentBodyFatChanged += new EventHandler<DietCalculatorEventArgs>( model_PercentBodyFatChanged );
            model.LeanBodyMassChanged += new EventHandler<DietCalculatorEventArgs>( model_LeanBodyMassChanged );
            model.CaloriesPerDayChanged += new EventHandler<DietCalculatorEventArgs>( model_CaloriesPerDayChanged );

            tbAge.TextChanged += new TextChangedEventHandler( tbAge_TextChanged );
            cbIsMale.Checked += new RoutedEventHandler( cbIsMale_Checked );
			cbIsMale.Unchecked += new RoutedEventHandler( cbIsMale_Unchecked );
            tbWeight.TextChanged += new TextChangedEventHandler( tbWeight_TextChanged );
            tbHeight.TextChanged += new TextChangedEventHandler( tbHeight_TextChanged );
			tbWaist.TextChanged += new TextChangedEventHandler(tbWaist_TextChanged);
            tbHips.TextChanged += new TextChangedEventHandler( tbHips_TextChanged );
            tbIdealWeight.TextChanged += new TextChangedEventHandler( tbIdealWeight_TextChanged );
            tbIdealBMI.TextChanged += new TextChangedEventHandler( tbIdealBMI_TextChanged );
            tbCholesterol.TextChanged += new TextChangedEventHandler( tbCholesterol_TextChanged );
            tbHDL.TextChanged += new TextChangedEventHandler( tbHDL_TextChanged );
            tbNeck.TextChanged += new TextChangedEventHandler( tbNeck_TextChanged );
            rbSedentary.Checked += new RoutedEventHandler( rbSedentary_Checked );
            rbModerate.Checked += new RoutedEventHandler( rbModerate_Checked );
            rbActive.Checked += new RoutedEventHandler( rbActive_Checked );
        }

        public bool HipsReadOnly
        {
            get
            {
                return tbHips.IsReadOnly;
            }
            set
            {
                tbHips.IsReadOnly = value;
            }
        }

        #region Model event handlers
        private void model_CaloriesPerDayChanged( object sender, DietCalculatorEventArgs e )
        {
            tbCaloriesPerDay.Text = e.CaloriesPerDay.ToString();
        }

        private void model_LeanBodyMassChanged( object sender, DietCalculatorEventArgs e )
        {
            tbLeanBodyMass.Text = e.LeanBodyMass.ToString();
        }

        private void model_PercentBodyFatChanged( object sender, DietCalculatorEventArgs e )
        {
            tbPercentBodyFat.Text = e.PercentBodyFat.ToString();
        }

        private void model_WaistHeightRatioChanged( object sender, DietCalculatorEventArgs e )
        {
            tbWaistHeightRatio.Text = e.WaistHeightRatio.ToString();
        }

        private void model_BMIChanged( object sender, DietCalculatorEventArgs e )
        {
            tbBMI.Text = e.BMI.ToString();
        }

        private void model_CholesterolResultChanged( object sender, DietCalculatorEventArgs e )
        {
            tbCholesterolResult.Text = e.CholesterolResult;
        }

        private void model_CholesterolRatioChanged( object sender, DietCalculatorEventArgs e )
        {
            tbCholesterolRatio.Text = e.CholesterolRatio.ToString();
        }

        private void model_WeightResultChanged( object sender, DietCalculatorEventArgs e )
        {
            tbWeightResult.Text = e.WeightResult;
        }

        private void model_WaistResultChanged( object sender, DietCalculatorEventArgs e )
        {
            tbWaistResult.Text = e.WaistResult;
        }

        private void model_WaistHipsRatioChanged( object sender, DietCalculatorEventArgs e )
        {
            tbWaistHipsRatio.Text = e.WaistHipsRatio.ToString();
        }

        private void model_IdealBMIChanged( object sender, DietCalculatorEventArgs e )
        {
            tbIdealBMI.Text = e.IdealBMI.ToString();
        }

        private void model_IdealWeightChanged( object sender, DietCalculatorEventArgs e )
        {
            tbIdealWeight.Text = e.IdealWeight.ToString();
        }
        #endregion

        private void tbAge_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetAge( StringToNumberUtility.GetInt32( tbAge.Text, 0 ) );
        }

        private void cbIsMale_Checked( object sender, RoutedEventArgs e )
        {
            controller.SetGender( cbIsMale.IsChecked.HasValue && cbIsMale.IsChecked.Value );
        }

		private void cbIsMale_Unchecked( object sender, RoutedEventArgs e )
		{
			controller.SetGender( cbIsMale.IsChecked.HasValue && cbIsMale.IsChecked.Value );
		}

        private void tbWeight_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetWeight( StringToNumberUtility.GetDouble( tbWeight.Text, 0.00 ) );
        }

        private void tbHeight_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetHeight( StringToNumberUtility.GetDouble( tbHeight.Text, 0.00 ) );
        }

        private void tbWaist_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetWaist( StringToNumberUtility.GetDouble( tbWaist.Text, 0.00 ) );
        }

        private void tbHips_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetHips( StringToNumberUtility.GetDouble( tbHips.Text, 0.00 ) );
        }

        private void tbIdealWeight_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetIdealWeight( StringToNumberUtility.GetDouble( tbIdealWeight.Text, 0.00 ) );
        }

        private void tbIdealBMI_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetIdealBMI( StringToNumberUtility.GetDouble( tbIdealBMI.Text, 0.00 ) );
        }

        private void tbCholesterol_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetCholesterol( StringToNumberUtility.GetDouble( tbCholesterol.Text, 0.00 ) );
        }

        private void tbHDL_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetHDL( StringToNumberUtility.GetDouble( tbHDL.Text, 0.00 ) );
        }

        private void tbNeck_TextChanged( object sender, TextChangedEventArgs e )
        {
            controller.SetNeck( StringToNumberUtility.GetDouble( tbNeck.Text, 0.00 ) );
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
