using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using DietCalculator.Core;

namespace DietCalculator.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public static UIFont Font = UIFont.FromName ("HelveticaNeue-Light", 14);
		public static UIColor Color = UIColor.FromRGB (255, 255, 255);
		public static UIColor SecondaryColor = UIColor.FromRGB (1, 101, 156);

		UIWindow window;
		RootElement rootElement;
		Section resultSection;


		DietDialogViewController mainDvc, resultDvc;
		UINavigationController nvc;

		IDietCalculatorModel model;
		IDietCalculatorController controller;


		// class-level declarations
		public override UIWindow Window {
			get;
			set;
		}

		/// <summary>
		/// Finisheds the launching.
		/// </summary>
		/// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
		/// <param name="application">Application.</param>
		/// <param name="launchOptions">Launch options.</param>
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			UINavigationBar.Appearance.TintColor = SecondaryColor;

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			model = new DietCalculatorModel ();

			model.IdealWeightChanged += (sender, e) => {
				Console.WriteLine(model.IdealWeight.ToString());
			};

			controller = new DietCalculatorController (model);

			CreateUI ();

			mainDvc = new DietDialogViewController (rootElement);
			nvc = new UINavigationController (mainDvc);

			window.RootViewController = nvc;
			window.MakeKeyAndVisible ();

			return true;
		}

		/// <summary>
		/// Creates the UI for DialogViewController using Element API
		/// </summary>
		private void CreateUI()
		{
			
			EntryElement ageElement, weightElement, heightElement, waistElement, hipsElement = null,
			idealWeightElement, idealBMIElement, cholestrolElement, hdlElement, neckElement;
			StringElement calculateButtonElement;

			Section waistHipsSection = null;

			// Gender Group and Section 
			var genderRadioGroup = new RadioGroup ("gender", 0);
			var femaleRadioElement = new DietRadioElement ("Female", "gender");
			var maleRadioElement = new DietRadioElement ("Male", "gender");
			var radioElementSection = new Section () {
				maleRadioElement,
				femaleRadioElement
			}; 

			// add hips element to wasit & hips section if female is selected
			femaleRadioElement.Tapped += delegate {
				if (!waistHipsSection.Elements.Contains (hipsElement = new NumericEntryElement ("Hips (in cm)", "ex. 88")))
					waistHipsSection.Add (hipsElement);
			};

			// remove hips element if male is selected.
			maleRadioElement.Tapped += delegate {
				if (waistHipsSection.Elements.Contains (hipsElement))
					waistHipsSection.Remove (hipsElement);
			};

			// Level of ActivityGroup & Section
			var levelOfActivityRadioGroup = new RadioGroup ("levelOfActivity", 2);
			var levelOfActivitySection = new Section () {
				new DietRadioElement (LevelOfActivity.Active.ToString(), "levelOfActivity"),
				new DietRadioElement (LevelOfActivity.Moderate.ToString(), "levelOfActivity"),
				new DietRadioElement (LevelOfActivity.Sedentary.ToString(), "levelOfActivity")
			};

			// Create Elements on the rootElement. This will be added to the DialogViewController's root.
			rootElement = new RootElement ("Diet Calculator") { 
				new Section(){
					(ageElement = new NumericEntryElement("Age","ex. 25"){ KeyboardType = UIKeyboardType.NumberPad }),
					(new DietRootElement("Gender", genderRadioGroup){radioElementSection})
				},
				new Section("Height & Weight"){
					(weightElement = new NumericEntryElement("Weight (in kg)","ex. 65")),
					(heightElement = new NumericEntryElement("Height (in cm)","ex. 170"))
				},  (waistHipsSection = new Section ("Waist & Hips") {
					(waistElement = new NumericEntryElement("Waist (in cm)", "ex. 47"))
					/* hips element will be added here if female is selected*/
				}),
				new Section("Ideal Weight & BMI"){
					(idealWeightElement = new NumericEntryElement("Ideal Weight (in kg)", "ex. 45")),
					(idealBMIElement = new NumericEntryElement("Ideal BMI (in kg/m2)","ex. 18"))
				},
				new Section("Cholestrol & HDL"){
					(cholestrolElement = new NumericEntryElement("Cholestrol (in mmol/L)", "ex. 5.17")),
					(hdlElement = new NumericEntryElement("HDL (in mmol/L)","ex. 1.56"))
				},
				new Section("Neck"){
					(neckElement = new NumericEntryElement("Neck (in cm)","ex. 30")),
				},
				new Section(){
					new DietRootElement ("Level Of Activity", levelOfActivityRadioGroup) { levelOfActivitySection }
				},
				/* Calculate Button*/
				new Section()
				{
					(calculateButtonElement = new DietStringElement("Calculate", 
					    /* On Calculate Click create the resulting UI*/
					   delegate {
						/* exising code from SL MVC project */
						controller.SetAge( StringToNumberUtility.GetInt32( ageElement.Value, 0 ) );
						controller.SetGender( genderRadioGroup.Selected == 0 ? true : false);
						controller.SetWeight( StringToNumberUtility.GetDouble( weightElement.Value, 0.00 ) );
						controller.SetHeight( StringToNumberUtility.GetDouble( heightElement.Value, 0.00 ) );
						controller.SetWaist( StringToNumberUtility.GetDouble( waistElement.Value, 0.00 ) );
						controller.SetHips( StringToNumberUtility.GetDouble((hipsElement == null ? null : hipsElement.Value), 0.00 ) );
						controller.SetIdealWeight( StringToNumberUtility.GetDouble( idealWeightElement.Value, 0.00 ) );
						controller.SetIdealBMI( StringToNumberUtility.GetDouble( idealBMIElement.Value, 0.00 ) );
						controller.SetCholesterol( StringToNumberUtility.GetDouble( cholestrolElement.Value, 0.00 ) );
						controller.SetHDL( StringToNumberUtility.GetDouble( hdlElement.Value, 0.00 ) );
						controller.SetNeck( StringToNumberUtility.GetDouble( neckElement.Value, 0.00 ) );

						var selectedActivity = levelOfActivitySection.Elements[levelOfActivityRadioGroup.Selected].Caption;
						controller.SetActivity( ( LevelOfActivity )Enum.Parse(typeof(LevelOfActivity), selectedActivity ));

						 resultSection = new Section ("Results") {
					
							new DietStringElement("Calories Per Day: ", model.CaloriesPerDay.ToString()),
							new DietStringElement("Lean Body Mass: ", model.LeanBodyMass.ToString()),
							new DietStringElement("Fat: ", model.PercentBodyFat.ToString() + " %"),
							new DietStringElement("Waist Hips Label: ", model.WaistHipsRatio.ToString() + " cm"),
							new DietStringElement("BMI Ratio: ", model.BMI.ToString()),
							new DietStringElement("Cholestrol Ratio: ", model.CholesterolRatio.ToString() + " mmol/L"),
							new DietStringElement("Waist Height Ratio: ", model.WaistHeightRatio.ToString() + " cm"),
							new DietStringElement("Ideal Weight: ", model.IdealWeight.ToString() + " kg"),

						};

						resultDvc = new DietDialogViewController(new RootElement("Results"){ resultSection }, true);
						nvc.PushViewController(resultDvc, true);

					}))
				}
			};

			// subscribe to IdealBMI and IdealWeight changed events on the model to update the UI
			model.IdealBMIChanged += (sender, e) => {
				idealBMIElement.Value = e.IdealBMI.ToString();
			};

			model.IdealWeightChanged += (sender, e) => {
				idealWeightElement.Value = e.IdealWeight.ToString();
			};

			// Since Ideal BMI has to be calculated based on the Ideal weight, set all the fields in 
			// the controller that are used for calcaulation
			idealWeightElement.Changed += (sender, e) => {

				controller.SetWeight( StringToNumberUtility.GetDouble( weightElement.Value, 0.00 ) );
				controller.SetHeight( StringToNumberUtility.GetDouble( heightElement.Value, 0.00 ) );

				controller.SetIdealWeight( StringToNumberUtility.GetDouble( idealWeightElement.Value, 0.00 ) );

			};
			idealBMIElement.Changed += (sender, e) => {
				controller.SetWeight( StringToNumberUtility.GetDouble( weightElement.Value, 0.00 ) );
				controller.SetHeight( StringToNumberUtility.GetDouble( heightElement.Value, 0.00 ) );
				controller.SetIdealBMI( StringToNumberUtility.GetDouble( idealBMIElement.Value, 0.00 ) );
			};

			calculateButtonElement.Alignment = UITextAlignment.Center;
		}
	}
}

