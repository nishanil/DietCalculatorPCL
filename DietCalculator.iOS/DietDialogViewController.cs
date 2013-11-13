using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace DietCalculator.iOS
{
	public class DietDialogViewController : DialogViewController
	{
		public DietDialogViewController (RootElement rootElement) : base(rootElement)
		{
			Style = UITableViewStyle.Grouped;
		}
		public DietDialogViewController (RootElement rootElement, bool pushing)  : base(rootElement, pushing)
		{

		}

		public override void LoadView ()
		{
			base.LoadView ();
			TableView.BackgroundView = null;
			TableView.BackgroundColor = AppDelegate.Color;
			TableView.SeparatorColor = AppDelegate.SecondaryColor;
		}

	}
}

