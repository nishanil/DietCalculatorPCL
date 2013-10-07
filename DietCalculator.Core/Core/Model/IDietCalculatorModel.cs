using System;


namespace DietCalculator.Core
{
	public interface IDietCalculatorModel
	{
		int Age
		{
			get;
			set;
		}

		bool IsMale
		{
			get;
			set;
		}

		double Weight
		{
			get;
			set;
		}

		double Height
		{
			get;
			set;
		}

		double Waist
		{
			get;
			set;
		}

		double Hips
		{
			get;
			set;
		}

        bool HipsEnabled
        {
            get;
        }

		double BMI
		{
			get;
		}

		double WaistHipsRatio
		{
			get;
		}

		double IdealWeight
		{
			get;
			set;
		}

		double IdealBMI
		{
			get;
			set;
		}

		string WeightResult
		{
			get;
		}

		string WaistResult
		{
			get;
		}

		double Cholesterol
		{
			get;
			set;
		}

		double HDL
		{
			get;
			set;
		}

		double CholesterolRatio
		{
			get;
		}

		string CholesterolResult
		{
			get;
		}

		double Neck
		{
			get;
			set;
		}

		LevelOfActivity Activity
		{
			get;
			set;
		}

		double WaistHeightRatio
		{
			get;
		}

		double PercentBodyFat
		{
			get;
		}

		double LeanBodyMass
		{
			get;
		}

        double CaloriesPerDay
        {
            get;
        }

		string LoadWeightResult();
		string LoadWaistResult();
		string LoadCholesterolResult();

		event EventHandler<DietCalculatorEventArgs> ModelChanged;
		event EventHandler<DietCalculatorEventArgs> ActivityChanged;
		event EventHandler<DietCalculatorEventArgs> AgeChanged;
		event EventHandler<DietCalculatorEventArgs> CholesterolChanged;
		event EventHandler<DietCalculatorEventArgs> CholesterolRatioChanged;
		event EventHandler<DietCalculatorEventArgs> CholesterolResultChanged;
		event EventHandler<DietCalculatorEventArgs> HDLChanged;
		event EventHandler<DietCalculatorEventArgs> HeightChanged;
		event EventHandler<DietCalculatorEventArgs> HipsChanged;
        event EventHandler<DietCalculatorEventArgs> HipsEnabledChanged;
		event EventHandler<DietCalculatorEventArgs> IdealBMIChanged;
		event EventHandler<DietCalculatorEventArgs> IdealWeightChanged;
		event EventHandler<DietCalculatorEventArgs> IsMaleChanged;
		event EventHandler<DietCalculatorEventArgs> LeanBodyMassChanged;
		event EventHandler<DietCalculatorEventArgs> NeckChanged;
		event EventHandler<DietCalculatorEventArgs> PercentBodyFatChanged;
		event EventHandler<DietCalculatorEventArgs> BMIChanged;
		event EventHandler<DietCalculatorEventArgs> WaistChanged;
		event EventHandler<DietCalculatorEventArgs> WaistHeightRatioChanged;
		event EventHandler<DietCalculatorEventArgs> WaistHipsRatioChanged;
		event EventHandler<DietCalculatorEventArgs> WaistResultChanged;
		event EventHandler<DietCalculatorEventArgs> WeightChanged;
		event EventHandler<DietCalculatorEventArgs> WeightResultChanged;
        event EventHandler<DietCalculatorEventArgs> CaloriesPerDayChanged;
	}

	public enum LevelOfActivity
	{
		None = 3,
		Sedentary = 0,
		Moderate = 1,
		Active = 2
	}
}
