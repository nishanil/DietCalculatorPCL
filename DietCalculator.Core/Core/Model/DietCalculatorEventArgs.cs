using System;


namespace DietCalculator.Core
{
	public class DietCalculatorEventArgs : EventArgs
	{
		public DietCalculatorEventArgs( IDietCalculatorModel model )
		{
            this.Activity = model.Activity;
            this.Age = model.Age;
            this.BMI = model.BMI;
            this.CaloriesPerDay = model.CaloriesPerDay;
            this.Cholesterol = model.Cholesterol;
            this.CholesterolRatio = model.CholesterolRatio;
            this.CholesterolResult = model.CholesterolResult;
            this.HDL = model.HDL;
            this.Height = model.Height;
            this.Hips = model.Hips;
            this.HipsEnabled = model.HipsEnabled;
            this.IdealBMI = model.IdealBMI;
            this.IdealWeight = model.IdealWeight;
            this.IsMale = model.IsMale;
            this.LeanBodyMass = model.LeanBodyMass;
            this.Neck = model.Neck;
            this.Waist = model.Waist;
            this.WaistHeightRatio = model.WaistHeightRatio;
            this.WaistHipsRatio = model.WaistHipsRatio;
            this.WaistResult = model.WaistResult;
            this.Weight = model.Weight;
            this.WeightResult = model.WeightResult;
			this.PercentBodyFat = model.PercentBodyFat;
		}

		public int Age
		{
			get;
			protected set;
		}

		public bool IsMale
		{
			get;
			protected set;
		}

		public double Weight
		{
			get;
			protected set;
		}

		public double Height
		{
			get;
            protected set;
		}

		public double Waist
		{
			get;
			protected set;
		}

		public double Hips
		{
			get;
			set;
		}

        public bool HipsEnabled
        {
            get;
            protected set;
        }

		public double BMI
		{
			get;
			protected set;
		}

		public double WaistHipsRatio
		{
			get;
			protected set;
		}

		public double IdealWeight
		{
			get;
			protected set;
		}

		public double IdealBMI
		{
			get;
			protected set;
		}

		public string WeightResult
		{
			get;
			protected set;
		}

		public string WaistResult
		{
			get;
			protected set;
		}

		public double Cholesterol
		{
			get;
			protected set;
		}

		public double HDL
		{
			get;
			protected set;
		}

		public double CholesterolRatio
		{
			get;
			protected set;
		}

		public string CholesterolResult
		{
			get;
			protected set;
		}

		public double Neck
		{
			get;
			protected set;
		}

		public LevelOfActivity Activity
		{
			get;
			protected set;
		}

		public double WaistHeightRatio
		{
			get;
			protected set;
		}

		public double PercentBodyFat
		{
			get;
			protected set;
		}

		public double LeanBodyMass
		{
			get;
			protected set;
		}

        public double CaloriesPerDay
        {
            get;
            protected set;
        }
	}
}
