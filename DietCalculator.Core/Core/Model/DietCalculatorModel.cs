using System;


namespace DietCalculator.Core
{
    public class DietCalculatorModel : IDietCalculatorModel
    {
        private int age = 0;
        private bool isMale = true;
        private double weight = 0.0;
        private double height = 0.0;
        private double waist = 0.0;
        private double hips = 0.0;
        private bool hipsEnabled = false;
        private double bmi = 0.0;
        private double waistHipsRatio = 0.0;
        private double idealWeight = 0.0;
        private double idealBmi = 0.0;
        private string weigthResult = String.Empty;
        private string waistResult = String.Empty;
        private double cholesterol = 0.0;
        private double hdl = 0.0;
        private double cholesterolRatio = 0.0;
        private string cholesterolResult = String.Empty;
        private double neck = 0.0;
        private LevelOfActivity levelOfActivity = LevelOfActivity.Sedentary;
        private double waistHeightRatio = 0.0;
        private double percentBodyFat = 0.0;
        private double leanBodyMass = 0.0;
        private double caloriesPerDay = 0.0;

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

        public DietCalculatorModel()
        {
        }

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
                this.OnAgeChanged( new DietCalculatorEventArgs( this ) );
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
                this.HipsEnabled = value == false;
                this.OnIsMaleChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnWeightChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnHeightChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnWaistChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnHipsChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnHipsEnabledChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnBMIChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnWaistHipsRatioChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnIdealWeightChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnIdealBMIChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnWeightResultChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnWaistResultChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnCholesterolChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnHDLChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnCholesterolRatioChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnCholesterolResultChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnNeckChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnActivityChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnWaistHeightRatioChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnPercentBodyFatChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnLeanBodyMassChanged( new DietCalculatorEventArgs( this ) );
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
                this.OnCaloriesPerDayChanged( new DietCalculatorEventArgs( this ) );
            }
        }

        protected virtual void OnModelChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.ModelChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnActivityChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.ActivityChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnAgeChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.AgeChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnCholesterolChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.CholesterolChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnCholesterolRatioChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.CholesterolRatioChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnCholesterolResultChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.CholesterolResultChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnHDLChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.HDLChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnHeightChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.HeightChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnHipsChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.HipsChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnHipsEnabledChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.HipsEnabledChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnIdealBMIChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.IdealBMIChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnIdealWeightChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.IdealWeightChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnIsMaleChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.IsMaleChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnLeanBodyMassChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.LeanBodyMassChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnNeckChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.NeckChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnPercentBodyFatChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.PercentBodyFatChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnBMIChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.BMIChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnWaistChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.WaistChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnWaistHeightRatioChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.WaistHeightRatioChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnWaistHipsRatioChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.WaistHipsRatioChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnWaistResultChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.WaistResultChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnWeightChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.WeightChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnWeightResultChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.WeightResultChanged;
            if ( temp != null )
                temp( this, e );
        }

        protected virtual void OnCaloriesPerDayChanged( DietCalculatorEventArgs e )
        {
            EventHandler<DietCalculatorEventArgs> temp = this.CaloriesPerDayChanged;
            if ( temp != null )
                temp( this, e );
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
                (1.0324 - 0.19077 * ( Math.Log10( this.Waist - this.Neck ) ) + 0.15456 * Math.Log10( this.Height )-450) );
            if( this.IsMale == false )
                fat = 495/ (
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
            if( this.IsMale == false )
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
    }
}
