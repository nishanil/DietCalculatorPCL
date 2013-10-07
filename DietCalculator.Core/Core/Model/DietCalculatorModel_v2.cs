using System;
using System.ComponentModel;


namespace DietCalculator.Core
{
    public class DietCalculatorModel_v2 : IDietCalculatorModel, INotifyPropertyChanged
    {
        private int age = 0;
        private bool isMale = true;
        private double weight = 0.0;
        private double height = 0.0;
        private double waist = 0.0;
        private double hips = 0.0;
        private bool hipsEnabled = true;
        private double bmi = 0.0;
        private double waistHipsRatio = 0.0;
        private double idealWeight = 0.0;
        private double idealBmi = 0.0;
        private string weigthResult = "Simulate Data Loading";
        private string waistResult = "Simulate Data Loading";
        private double cholesterol = 0.0;
        private double hdl = 0.0;
        private double cholesterolRatio = 0.0;
        private string cholesterolResult = "Simulate Data Loading";
        private double neck = 0.0;
        private LevelOfActivity levelOfActivity = LevelOfActivity.Sedentary;
        private double waistHeightRatio = 0.0;
        private double percentBodyFat = 0.0;
        private double leanBodyMass = 0.0;
        private double caloriesPerDay = 0.0;

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<DietCalculatorEventArgs> ModelChanged;
        public event EventHandler<DietCalculatorEventArgs> ActivityChanged;
        public event EventHandler<DietCalculatorEventArgs> AgeChanged;
        public event EventHandler<DietCalculatorEventArgs> CholesterolChanged;
        public event EventHandler<DietCalculatorEventArgs> CholesterolRatioChanged;
        public event EventHandler<DietCalculatorEventArgs> CholesterolResultChanged;
        public event EventHandler<DietCalculatorEventArgs> HDLChanged;
        public event EventHandler<DietCalculatorEventArgs> HeightChanged;
        public event EventHandler<DietCalculatorEventArgs> HipsChanged;
        public event EventHandler<DietCalculatorEventArgs> HipsEnabledChanged;
        public event EventHandler<DietCalculatorEventArgs> IdealBMIChanged;
        public event EventHandler<DietCalculatorEventArgs> IdealWeightChanged;
        public event EventHandler<DietCalculatorEventArgs> IsMaleChanged;
        public event EventHandler<DietCalculatorEventArgs> LeanBodyMassChanged;
        public event EventHandler<DietCalculatorEventArgs> NeckChanged;
        public event EventHandler<DietCalculatorEventArgs> PercentBodyFatChanged;
        public event EventHandler<DietCalculatorEventArgs> BMIChanged;
        public event EventHandler<DietCalculatorEventArgs> WaistChanged;
        public event EventHandler<DietCalculatorEventArgs> WaistHeightRatioChanged;
        public event EventHandler<DietCalculatorEventArgs> WaistHipsRatioChanged;
        public event EventHandler<DietCalculatorEventArgs> WaistResultChanged;
        public event EventHandler<DietCalculatorEventArgs> WeightChanged;
        public event EventHandler<DietCalculatorEventArgs> WeightResultChanged;
        public event EventHandler<DietCalculatorEventArgs> CaloriesPerDayChanged;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if ( this.Age == value )
                    return;

                age = value;
                this.CaloriesPerDay = this.CalculateCaloriesPerDay();
                this.OnPropertyChanged( "Age" );
            }
        }

        public bool IsMale
        {
            get
            {
                return isMale;
            }
            set
            {
                if ( this.IsMale == value )
                    return;

                isMale = value;
                this.CaloriesPerDay = this.CalculateCaloriesPerDay();
                this.HipsEnabled = value;
                this.OnPropertyChanged( "IsMale" );
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if ( this.Weight == value )
                    return;

                weight = value;
                this.BMI = this.CalculateBMI();
                this.LeanBodyMass = this.CalculateLeanBodyMass();
                this.CaloriesPerDay = this.CalculateCaloriesPerDay();
                this.OnPropertyChanged( "Weight" );
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if ( this.Height == value )
                    return;

                height = value;
                this.IdealWeight = this.CalculateIdealWeight();
                this.IdealBMI = this.CalculateIdealBMI();
                this.BMI = this.CalculateBMI();
                this.WaistHeightRatio = this.CalculateWaistHeightRatio();
                this.PercentBodyFat = this.CalculatePercentBodyFat();
                this.CaloriesPerDay = this.CalculateCaloriesPerDay();
                this.OnPropertyChanged( "Height" );
            }
        }

        public double Waist
        {
            get
            {
                return waist;
            }
            set
            {
                if ( this.Waist == value )
                    return;

                waist = value;
                this.WaistHipsRatio = this.CalculateWaistHipsRatio();
                this.WaistHeightRatio = this.CalculateWaistHeightRatio();
                this.PercentBodyFat = this.CalculatePercentBodyFat();
                this.OnPropertyChanged( "Waist" );
            }
        }

        public double Hips
        {
            get
            {
                return hips;
            }
            set
            {
                if ( this.Hips == value )
                    return;

                hips = value;
                this.WaistHipsRatio = this.CalculateWaistHipsRatio();
                this.PercentBodyFat = this.CalculatePercentBodyFat();
                this.OnPropertyChanged( "Hips" );
            }
        }

        public bool HipsEnabled
        {
            get
            {
                return hipsEnabled;
            }
            protected set
            {
                if ( this.HipsEnabled == value )
                    return;

                hipsEnabled = value;
                this.OnPropertyChanged( "HipsEnabled" );
            }
        }

        public double BMI
        {
            get
            {
                return bmi;
            }
            protected set
            {
                if ( this.BMI == value )
                    return;

                bmi = value;
                this.OnPropertyChanged( "BMI" );
            }
        }

        public double WaistHipsRatio
        {
            get
            {
                return waistHipsRatio;
            }
            protected set
            {
                if ( this.WaistHipsRatio == value )
                    return;

                waistHipsRatio = value;
                this.OnPropertyChanged( "WaistHipsRatio" );
            }
        }

        public double IdealWeight
        {
            get
            {
                return idealWeight;
            }
            set
            {
                if ( this.IdealWeight == value )
                    return;

                idealWeight = value;
                this.IdealBMI = this.CalculateIdealBMI();
                this.OnPropertyChanged( "IdealWeight" );
            }
        }

        public double IdealBMI
        {
            get
            {
                return idealBmi;
            }
            set
            {
                if ( this.IdealBMI == value )
                    return;

                idealBmi = value;
                this.IdealWeight = this.CalculateIdealWeight();
                this.OnPropertyChanged( "IdealBMI" );
            }
        }

        public string WeightResult
        {
            get
            {
                return weigthResult;
            }
            protected set
            {
                if ( this.WeightResult == value )
                    return;

                weigthResult = value;
                this.OnPropertyChanged( "WeightResult" );
            }
        }

        public string WaistResult
        {
            get
            {
                return waistResult;
            }
            protected set
            {
                if ( this.WaistResult == value )
                    return;

                waistResult = value;
                this.OnPropertyChanged( "WaistResult" );
            }
        }

        public double Cholesterol
        {
            get
            {
                return cholesterol;
            }
            set
            {
                if ( this.Cholesterol == value )
                    return;

                cholesterol = value;
                this.CholesterolRatio = this.CalculateCholesterolRatio();
                this.OnPropertyChanged( "Cholesterol" );
            }
        }

        public double HDL
        {
            get
            {
                return hdl;
            }
            set
            {
                if ( this.HDL == value )
                    return;

                hdl = value;
                this.CholesterolRatio = this.CalculateCholesterolRatio();
                this.OnPropertyChanged( "HDL" );
            }
        }

        public double CholesterolRatio
        {
            get
            {
                return cholesterolRatio;
            }
            protected set
            {
                if ( this.CholesterolRatio == value )
                    return;

                cholesterolRatio = value;
                this.OnPropertyChanged( "CholesterolRatio" );
            }
        }

        public string CholesterolResult
        {
            get
            {
                return cholesterolResult;
            }
            protected set
            {
                if ( this.CholesterolResult == value )
                    return;

                cholesterolResult = value;
                this.OnPropertyChanged( "CholesterolResult" );
            }
        }

        public double Neck
        {
            get
            {
                return neck;
            }
            set
            {
                if ( this.Neck == value )
                    return;

                neck = value;
                this.PercentBodyFat = this.CalculatePercentBodyFat();
                this.OnPropertyChanged( "Neck" );
            }
        }

        public LevelOfActivity Activity
        {
            get
            {
                return levelOfActivity;
            }
            set
            {
                if ( this.Activity == value )
                    return;

                levelOfActivity = value;
                this.CaloriesPerDay = this.CalculateCaloriesPerDay();
                this.OnPropertyChanged( "Activity" );
            }
        }

        public double WaistHeightRatio
        {
            get
            {
                return waistHeightRatio;
            }
            protected set
            {
                if ( this.WaistHeightRatio == value )
                    return;

                waistHeightRatio = value;
                this.OnPropertyChanged( "WaistHeightRatio" );
            }
        }

        public double PercentBodyFat
        {
            get
            {
                return percentBodyFat;
            }
            protected set
            {
                if ( this.PercentBodyFat == value )
                    return;

                percentBodyFat = value;
                this.LeanBodyMass = this.CalculateLeanBodyMass();
                this.OnPropertyChanged( "PercentBodyFat" );
            }
        }

        public double LeanBodyMass
        {
            get
            {
                return leanBodyMass;
            }
            protected set
            {
                if ( this.LeanBodyMass == value )
                    return;

                leanBodyMass = value;
                this.OnPropertyChanged( "LeanBodyMass" );
            }
        }

        public string LoadWeightResult()
        {
            throw new NotImplementedException();
        }

        public string LoadWaistResult()
        {
            throw new NotImplementedException();
        }

        public string LoadCholesterolResult()
        {
            throw new NotImplementedException();
        }

        public double CaloriesPerDay
        {
            get
            {
                return caloriesPerDay;
            }
            protected set
            {
                if ( this.CaloriesPerDay == value )
                    return;

                caloriesPerDay = value;
                this.OnPropertyChanged( "CaloriesPerDay" );
            }
        }

        private double CalculateIdealWeight()
        {
            if ( this.Height == 0 )
                return 0;

            return Math.Round( this.IdealBMI * Math.Pow( ( this.Height / 100 ), 2 ) );
        }

        private double CalculateIdealBMI()
        {
            if ( this.Height == 0 )
                return 0;

            return Math.Round( this.IdealWeight / Math.Pow( ( this.Height / 100 ), 2 ) );
        }

        private double CalculateWaistHipsRatio()
        {
            if ( this.Hips == 0 )
                return 0;

            return Math.Round( this.Waist / this.Hips, 2 );
        }

        private double CalculateCholesterolRatio()
        {
            if ( this.HDL == 0 )
                return 0;

            return Math.Round( this.Cholesterol / this.HDL, 2 );
        }

        private double CalculateBMI()
        {
            if ( this.Height == 0 )
                return 0;

            return Math.Round( this.Weight / Math.Pow( this.Height / 100, 2 ), 2 );
        }

        private double CalculateWaistHeightRatio()
        {
            if ( this.Height == 0 )
                return 0;

            return Math.Round( this.Waist / this.Height, 2 );
        }

        private double CalculatePercentBodyFat()
        {
            if ( this.Waist - this.Neck == 0 ||
                 this.Waist + this.Hips - this.Neck == 0 ||
                 this.Height == 0 )
                return 0;

            double fat = 495 / (
                ( 1.0324 - 0.19077 * ( Math.Log10( this.Waist - this.Neck ) ) + 0.15456 * Math.Log10( this.Height ) - 450 ) );
            if ( this.IsMale == false )
                fat = 495 / (
                    ( 1.29579 - 0.35004 * ( Math.Log10( this.Waist + this.Hips - this.Neck ) ) + 0.22100 * Math.Log10( this.Height ) - 450 ) );

            return Math.Round( fat, 2 );
        }

        private double CalculateLeanBodyMass()
        {
            return Math.Round( this.Weight * this.PercentBodyFat );
        }

        private double CalculateBMR()
        {
            double bmr = 66 + ( 13.7 * this.Weight ) + ( 5 * this.Height ) + ( 6.8 * this.Age );
            if ( this.IsMale == false )
                bmr = 655 + ( 19.6 * this.Weight ) + ( 1.8 * this.Height ) + ( 4.7 * this.Age );

            return Math.Round( bmr, 2 );
        }

        private double CalculateCaloriesPerDay()
        {
            double calories = this.CalculateBMR();

            switch ( this.Activity )
            {
                case LevelOfActivity.Active:
                    calories = calories * 1.9;
                    break;
                case LevelOfActivity.Moderate:
                    calories = calories * 1.55;
                    break;
                case LevelOfActivity.Sedentary:
                    calories = calories * 1.2;
                    break;
                default:
                    calories = 0;
                    break;
            }

            return Math.Round( calories, 2 );
        }

        protected virtual void OnPropertyChanged( string info )
        {
            PropertyChangedEventHandler temp = this.PropertyChanged;
            if ( temp != null )
                temp( this, new PropertyChangedEventArgs( info ) );
        }
    }
}
