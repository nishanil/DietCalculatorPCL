
using System;


namespace DietCalculator.Core
{
    public class DietCalculatorController : IDietCalculatorController
    {
        private IDietCalculatorView view;
        private IDietCalculatorModel model;

		public DietCalculatorController(IDietCalculatorModel model )
        {
            this.model = model;
        }

        public DietCalculatorController(IDietCalculatorView view, IDietCalculatorModel model) : this (model)
        {
            this.view = view;

            view.SetModel(model);
            view.SetController(this);

            model.HipsEnabledChanged += new EventHandler<DietCalculatorEventArgs>(model_HipsEnabledChanged);
        }

        public void SetActivity( LevelOfActivity activity )
        {
            model.Activity = activity;
        }

        public void SetGender( bool isMale )
        {
            model.IsMale = isMale;
        }

        public void SetWeight( double weight )
        {
            model.Weight = weight;
        }

        public void SetHeight( double height )
        {
            model.Height = height;
        }

        public void SetWaist( double waist )
        {
            model.Waist = waist;
        }

        public void SetHips( double hips )
        {
            model.Hips = hips;
        }

        public void SetIdealWeight( double idealWeight )
        {
            model.IdealWeight = idealWeight;
        }

        public void SetIdealBMI( double idealBmi )
        {
            model.IdealBMI = idealBmi;
        }

        public void SetCholesterol( double cholesterol )
        {
            model.Cholesterol = cholesterol;
        }

        public void SetHDL( double hdl )
        {
            model.HDL = hdl;
        }

        public void SetNeck( double neck )
        {
            model.Neck = neck;
        }

        public void SetAge( int age )
        {
            model.Age = age;
        }

        private void model_HipsEnabledChanged( object sender, DietCalculatorEventArgs e )
        {
           view.HipsReadOnly = e.HipsEnabled == false;
        }
    }
}
