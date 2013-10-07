// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
using DietCalculator.Core;
using DietCalculator.WinRT.Common;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace DietCalculator.WinRT
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class HomePage : DietCalculator.WinRT.Common.LayoutAwarePage
    {
        IDietCalculatorModel model;
        IDietCalculatorController controller;

        public HomePage()
        {
            this.InitializeComponent();

            // MVVM is not used in this example. We're porting an existing sample from Silverlight MVC
            // we will make use of the existing pattern to achieve the results
            model = new DietCalculatorModel();
            controller = new DietCalculatorController(model);

            // bydefault Male is Selected, hence collapse hips
            txtHips.Visibility = tblHips.Visibility =  Visibility.Collapsed;

            cmbGender.SelectionChanged += (sender, args) =>
            {
                var isSelectedItemMale = ((string)cmbGender.SelectedItem == "Male");
                txtHips.Visibility = tblHips.Visibility = isSelectedItemMale ? Visibility.Collapsed : Visibility.Visible;
               
                // corner case: reset hipsText to empty if the user had typed in hips and later changed the gender
                if (isSelectedItemMale) txtHips.Text = string.Empty;
            };

            // subscribe to IdealBMI and IdealWeight changed events on the model to update the UI
            // as per the implementation in the core project, 
            // any change in IdealBMI or IdealWeight are notified using appropriate event handlers
            model.IdealBMIChanged += (sender, e) =>
            {
                txtIdealBMI.Text = e.IdealBMI.ToString();
            };

            model.IdealWeightChanged += (sender, e) =>
            {
                txtIdealWeight.Text = e.IdealWeight.ToString();
            };
            
            txtIdealWeight.TextChanged += (sender, e) =>
            {
                controller.SetWeight(StringToNumberUtility.GetDouble(txtWeight.Text, 0.00));
                controller.SetHeight(StringToNumberUtility.GetDouble(txtHeight.Text, 0.00));
                controller.SetIdealWeight(StringToNumberUtility.GetDouble(txtIdealWeight.Text, 0.00));

            };
            txtIdealBMI.TextChanged += (sender, e) =>
            {
                controller.SetWeight(StringToNumberUtility.GetDouble(txtWeight.Text, 0.00));
                controller.SetHeight(StringToNumberUtility.GetDouble(txtHeight.Text, 0.00));
                controller.SetIdealBMI(StringToNumberUtility.GetDouble(txtIdealBMI.Text, 0.00));
            };

        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void CaclculateGridViewItem_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            controller.SetAge(StringToNumberUtility.GetInt32(txtAge.Text, 0));
            controller.SetGender((cmbGender.SelectedIndex ==0 ) ? true : false);
            controller.SetWeight(StringToNumberUtility.GetDouble(txtWeight.Text, 0.00));
            controller.SetHeight(StringToNumberUtility.GetDouble(txtHeight.Text, 0.00));
            controller.SetWaist(StringToNumberUtility.GetDouble(txtWaist.Text, 0.00));
            controller.SetHips(StringToNumberUtility.GetDouble((!string.IsNullOrEmpty(txtHips.Text) ? txtHips.Text : null), 0.00));
            controller.SetIdealWeight(StringToNumberUtility.GetDouble(txtIdealWeight.Text, 0.00));
            controller.SetIdealBMI(StringToNumberUtility.GetDouble(txtIdealBMI.Text, 0.00));
            controller.SetCholesterol(StringToNumberUtility.GetDouble(txtCholestrol.Text, 0.00));
            controller.SetHDL(StringToNumberUtility.GetDouble(txtHDL.Text, 0.00));
            controller.SetNeck(StringToNumberUtility.GetDouble(txtNeck.Text, 0.00));
            var selectedActivity = (string)cmbLevelOfActivity.SelectedItem;
            controller.SetActivity((LevelOfActivity)Enum.Parse(typeof(LevelOfActivity), selectedActivity));

            this.Frame.Navigate(typeof (ResultsPage), model);
        }

       
    }
}
