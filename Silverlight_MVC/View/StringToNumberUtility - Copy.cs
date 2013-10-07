using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Silverlight_MVC
{
    public sealed class StringToNumberUtility
    {
        public static int GetInt32( string text, int defaultValue )
        {
            int number = defaultValue;
            Int32.TryParse( text, out number );
            return number;
        }

        public static double GetDouble( string text, double defaultValue )
        {
            double number = defaultValue;
            Double.TryParse( text, out number );
            return number;
        }

        private StringToNumberUtility()
        {
        }
    }
}
