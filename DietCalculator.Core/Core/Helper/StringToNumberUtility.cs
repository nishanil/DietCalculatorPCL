using System;

namespace DietCalculator.Core
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

