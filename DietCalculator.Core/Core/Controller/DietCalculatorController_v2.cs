using System;


namespace DietCalculator.Core
{
    public class DietCalculatorController_v2 : IDietCalculatorController
    {
        private IDietCalculatorView view;
        private IDietCalculatorModel model;

        public DietCalculatorController_v2(IDietCalculatorView view, IDietCalculatorModel model) : this(model)
        {
            this.view = view;

            view.SetModel( model );
            view.SetController( this );
        }

        public DietCalculatorController_v2( IDietCalculatorModel model )
		
        {
            this.model = model;

        }

        public void SetActivity( LevelOfActivity activity )
        {
            model.Activity = activity;
        }

        public void SetGender( bool isMale )
        {
            throw new NotImplementedException();
        }

        public void SetWeight( double weight )
        {
            throw new NotImplementedException();
        }

        public void SetHeight( double height )
        {
            throw new NotImplementedException();
        }

        public void SetWaist( double waist )
        {
            throw new NotImplementedException();
        }

        public void SetHips( double hips )
        {
            throw new NotImplementedException();
        }

        public void SetIdealWeight( double idealWeight )
        {
            throw new NotImplementedException();
        }

        public void SetIdealBMI( double idealBmi )
        {
            throw new NotImplementedException();
        }

        public void SetCholesterol( double cholesterol )
        {
            throw new NotImplementedException();
        }

        public void SetHDL( double hdl )
        {
            throw new NotImplementedException();
        }

        public void SetNeck( double neck )
        {
            throw new NotImplementedException();
        }

        public void SetAge( int age )
        {
            throw new NotImplementedException();
        }
    }
}
