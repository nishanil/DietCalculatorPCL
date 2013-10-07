using System;


namespace DietCalculator.Core
{
    public interface IDietCalculatorController
    {
        void SetActivity( LevelOfActivity activity );
        void SetGender( bool isMale );
        void SetWeight( double weight );
        void SetHeight( double height );
        void SetWaist( double waist );
        void SetHips( double hips );
        void SetIdealWeight( double idealWeight );
        void SetIdealBMI( double idealBmi );
        void SetCholesterol( double cholesterol );
        void SetHDL( double hdl );
        void SetNeck( double neck );
        void SetAge( int age );
    }
}
