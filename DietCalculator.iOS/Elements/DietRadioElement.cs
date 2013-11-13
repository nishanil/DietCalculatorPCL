using System;
using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace DietCalculator.iOS
{
	public class DietRadioElement : RadioElement
	{
		public DietRadioElement (string caption, string group) : base(caption, group)
		{
		}

		public override MonoTouch.UIKit.UITableViewCell GetCell (MonoTouch.UIKit.UITableView tv)
		{
			var cell = base.GetCell (tv);
			cell.TextLabel.Font = AppDelegate.Font;
			cell.TextLabel.TextColor = UIColor.Black;
			return cell;
		}
	}
}

