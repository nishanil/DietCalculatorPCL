using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace DietCalculator.iOS
{
	public class DietStringElement : StringElement
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DietCalculator.iOS.DietStringElement"/> class.
		/// </summary>
		/// <param name="caption">Caption.</param>
		/// <param name="tapped">Tapped.</param>
		public DietStringElement (string caption, NSAction  tapped) : base(caption, tapped)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DietCalculator.iOS.DietStringElement"/> class.
		/// </summary>
		/// <param name="caption">Caption.</param>
		/// <param name="value">Value.</param>
		public DietStringElement (string caption, string value) : base(caption, value)
		{
		}

		/// <Docs>The containing table view.</Docs>
		/// <returns></returns>
		/// <summary>
		/// Gets the cell.
		/// </summary>
		/// <param name="tv">Tv.</param>
		public override UITableViewCell GetCell (UITableView tv)
		{
			var cell =  base.GetCell (tv);
			cell.TextLabel.Font = AppDelegate.Font;
			cell.TextLabel.TextColor = UIColor.Black;
			if (cell.DetailTextLabel != null) {
				cell.DetailTextLabel.Font = AppDelegate.Font;
				cell.DetailTextLabel.TextColor = UIColor.Black;
			}
			return cell;
		}
	}
}

