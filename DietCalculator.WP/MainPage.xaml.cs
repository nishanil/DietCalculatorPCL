using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DietCalculator.WP.Resources;
using DietCalculator.Core;

namespace DietCalculator.WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        IDietCalculatorModel model;
        IDietCalculatorController controller;

        public static IDietCalculatorModel CalculatedModel { get; set; }

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // MVVM is not used in this example. We're porting an existing sample from Silverlight MVC
            // we will make use of the existing pattern to achieve the results
            model = new DietCalculatorModel();
            controller = new DietCalculatorController(model);

            // bydefault Male is Selected, hence collapse hips
            txtHips.Visibility = tblHips.Visibility = Visibility.Collapsed;

            listGender.SelectionChanged += (sender, args) =>
            {
                var isSelectedItemMale = ((string)listGender.SelectedItem == "Male");
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

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
        private void BtnCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            controller.SetAge(StringToNumberUtility.GetInt32(txtAge.Text, 0));
            controller.SetGender((listGender.SelectedIndex == 0) ? true : false);
            controller.SetWeight(StringToNumberUtility.GetDouble(txtWeight.Text, 0.00));
            controller.SetHeight(StringToNumberUtility.GetDouble(txtHeight.Text, 0.00));
            controller.SetWaist(StringToNumberUtility.GetDouble(txtWaist.Text, 0.00));
            controller.SetHips(StringToNumberUtility.GetDouble((!string.IsNullOrEmpty(txtHips.Text) ? txtHips.Text : null), 0.00));
            controller.SetIdealWeight(StringToNumberUtility.GetDouble(txtIdealWeight.Text, 0.00));
            controller.SetIdealBMI(StringToNumberUtility.GetDouble(txtIdealBMI.Text, 0.00));
            controller.SetCholesterol(StringToNumberUtility.GetDouble(txtCholestrol.Text, 0.00));
            controller.SetHDL(StringToNumberUtility.GetDouble(txtHDL.Text, 0.00));
            controller.SetNeck(StringToNumberUtility.GetDouble(txtNeck.Text, 0.00));
            var selectedActivity = (string)listActivity.SelectedItem;
            controller.SetActivity((LevelOfActivity)Enum.Parse(typeof(LevelOfActivity), selectedActivity));

            // set the model to a public static property. This will be accessed from ResultsPage
            CalculatedModel = model;
            NavigationService.Navigate(new Uri("/ResultsPage.xaml", UriKind.Relative));
        }


    }
}