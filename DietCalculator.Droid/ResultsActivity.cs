using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DietCalculator.Droid
{
    [Activity(Label = "Diet Calculator", Icon = "@drawable/icon")]
    public class ResultsActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Results);

            FindViewById<TextView>(Resource.Id.caloriesPerDayResultText).Text = Intent.GetStringExtra("CaloriesPerDay");
            FindViewById<TextView>(Resource.Id.leanBodyMassResultText).Text = Intent.GetStringExtra("LeanBodyMass");
            FindViewById<TextView>(Resource.Id.fatResultText).Text = Intent.GetStringExtra("PercentBodyFat");
            FindViewById<TextView>(Resource.Id.waistHipsRatioResultText).Text = Intent.GetStringExtra("WaistHipsRatio");
            FindViewById<TextView>(Resource.Id.bmiRatioResultText).Text = Intent.GetStringExtra("BMI");
            FindViewById<TextView>(Resource.Id.cholestrolRatioResultText).Text = Intent.GetStringExtra("CholesterolRatio");
            FindViewById<TextView>(Resource.Id.waistHeightRatioResultText).Text = Intent.GetStringExtra("WaistHeightRatio");
            FindViewById<TextView>(Resource.Id.idealWeihtResultText).Text = Intent.GetStringExtra("IdealWeight");
        }
    }
}