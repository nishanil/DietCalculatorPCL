using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DietCalculator.Core;
using Java.Util.Logging;

namespace DietCalculator.Droid
{
    [Activity(Label = "Diet Calculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        IDietCalculatorModel model;
        IDietCalculatorController controller;

        /// <summary>
        /// OnCreate
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            model = new DietCalculatorModel();
            controller = new DietCalculatorController(model);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // retrieve the widgets in UI using FindByViewId to interact programmatically 
            var ageText = FindViewById<EditText>(Resource.Id.ageText);
            var genderSpinner = FindViewById<Spinner>(Resource.Id.genderSpinner);
            var levelOfActivitySpinner = FindViewById<Spinner>(Resource.Id.levelOfActivitySpinner);
            var calculateButton = FindViewById<Button>(Resource.Id.calculateButton);

            var weightText = FindViewById<EditText>(Resource.Id.weightText);
            var heightText = FindViewById<EditText>(Resource.Id.heightText);
            
            var waistText = FindViewById<EditText>(Resource.Id.waistText);
            var hipsLayout = FindViewById<LinearLayout>(Resource.Id.hipsLayout);
            var hipstText = FindViewById<EditText>(Resource.Id.hipsText);

            var idealWeightText = FindViewById<EditText>(Resource.Id.idealWeightText);
            var idealBMIText = FindViewById<EditText>(Resource.Id.idealBMIText);

            var cholestrolText = FindViewById<EditText>(Resource.Id.cholestrolText);
            var hdlText = FindViewById<EditText>(Resource.Id.hdlText);

            var neckText = FindViewById<EditText>(Resource.Id.neckText);

           // Assign "Male", "Female" values to spinner using ArrayAdapter. Refer Resources/Values/String.xml
            ArrayAdapter genderAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.gender_array,
                Resource.Layout.diet_spinner_item);
            genderAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            genderSpinner.Adapter = genderAdapter;

            // Hips should be visible only if "Female" is selected
            genderSpinner.ItemSelected += (sender, args) =>
            {
                var isSelectedItemMale = ((string) genderSpinner.SelectedItem == "Male");
                hipsLayout.Visibility =  isSelectedItemMale ? ViewStates.Gone : ViewStates.Visible;
                // corner case: reset hipsText to empty if the user had typed in hips and later changed the gender
                if (isSelectedItemMale) hipstText.Text = string.Empty;
            };
            // Assign "Active", "Moderate", "Sedentary" values to spinner using ArrayAdapter. Refer Resources/Values/String.xml
            ArrayAdapter levelOfActivityAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.levelOfActivity_array,
                Resource.Layout.diet_spinner_item);
            levelOfActivityAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            levelOfActivitySpinner.Adapter = levelOfActivityAdapter;

            // On Button Click, set appropriate values in the Controller Class 
            calculateButton.Click += (sender, args) =>
            {
                controller.SetAge(StringToNumberUtility.GetInt32(ageText.Text, 0));
                controller.SetGender((genderSpinner.SelectedItemId == 0) ? true : false);
                controller.SetWeight(StringToNumberUtility.GetDouble(weightText.Text, 0.00));
                controller.SetHeight(StringToNumberUtility.GetDouble(heightText.Text, 0.00));
                controller.SetWaist(StringToNumberUtility.GetDouble(waistText.Text, 0.00));
                controller.SetHips(StringToNumberUtility.GetDouble((!string.IsNullOrEmpty(hipstText.Text) ? hipstText.Text : null), 0.00));
                controller.SetIdealWeight(StringToNumberUtility.GetDouble(idealWeightText.Text, 0.00));
                controller.SetIdealBMI(StringToNumberUtility.GetDouble(idealBMIText.Text, 0.00));
                controller.SetCholesterol(StringToNumberUtility.GetDouble(cholestrolText.Text, 0.00));
                controller.SetHDL(StringToNumberUtility.GetDouble(hdlText.Text, 0.00));
                controller.SetNeck(StringToNumberUtility.GetDouble(neckText.Text, 0.00));
                var selectedActivity = (string)levelOfActivitySpinner.SelectedItem;
                controller.SetActivity((LevelOfActivity)Enum.Parse(typeof(LevelOfActivity), selectedActivity));

                // Since Model classes are already populated with the results, pass them to Result Activity 
                // using PutExtra method
                var resultIntent = new Intent(this, typeof (ResultsActivity));
                resultIntent.PutExtra("CaloriesPerDay", model.CaloriesPerDay.ToString());
                resultIntent.PutExtra("LeanBodyMass", model.LeanBodyMass.ToString());
                resultIntent.PutExtra("PercentBodyFat", model.PercentBodyFat.ToString() + " %");
                resultIntent.PutExtra("WaistHipsRatio", model.WaistHipsRatio.ToString() + " cm");
                resultIntent.PutExtra("BMI", model.BMI.ToString());
                resultIntent.PutExtra("CholesterolRatio", model.CholesterolRatio.ToString() + " mmol/L");
                resultIntent.PutExtra("WaistHeightRatio", model.WaistHeightRatio.ToString() + " cm");
                resultIntent.PutExtra("IdealWeight", model.IdealWeight.ToString() + " kg");
                StartActivity(resultIntent);
            };

            // subscribe to IdealBMI and IdealWeight changed events on the model to update the UI
            // as per the implementation in the core project, 
            // any change in IdealBMI or IdealWeight are notified using appropriate event handlers
            model.IdealBMIChanged += (sender, e) =>
            {
                idealBMIText.Text = e.IdealBMI.ToString();
            };

            model.IdealWeightChanged += (sender, e) =>
            {
                idealWeightText.Text = e.IdealWeight.ToString();
            };

            // Ideal BMI has to be calculated if user changes the IdealWeight.
            // Set all the fields in the controller that are used for calcaulation
            
            idealWeightText.TextChanged += (sender, e) =>
            {
                controller.SetWeight(StringToNumberUtility.GetDouble(weightText.Text, 0.00));
                controller.SetHeight(StringToNumberUtility.GetDouble(heightText.Text, 0.00));
                controller.SetIdealWeight(StringToNumberUtility.GetDouble(idealWeightText.Text, 0.00));

            };
            idealBMIText.TextChanged += (sender, e) =>
            {
                controller.SetWeight(StringToNumberUtility.GetDouble(weightText.Text, 0.00));
                controller.SetHeight(StringToNumberUtility.GetDouble(heightText.Text, 0.00));
                controller.SetIdealBMI(StringToNumberUtility.GetDouble(idealBMIText.Text, 0.00));
            };

        }
    }
}

