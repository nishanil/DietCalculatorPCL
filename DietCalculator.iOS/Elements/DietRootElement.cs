using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace DietCalculator.iOS
{
	public class DietRootElement : RootElement
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DietCalculator.iOS.DietRootElement"/> class.
		/// </summary>
		/// <param name="caption">Caption.</param>
		/// <param name="group">Group.</param>
		public DietRootElement (string caption, Group group) : base(caption, group)
		{
		}


		protected override UIViewController MakeViewController ()
		{
			var controller = base.MakeViewController () as DialogViewController;
			// if the base returns DialogViewController, then re-set to DietDialogViewController to override the default UI DVC.
			if (controller != null) {
				controller = new DietDialogViewController (controller.Root, true);
			}
			return controller;
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
			cell.DetailTextLabel.Font = AppDelegate.Font;
			cell.TextLabel.Font = AppDelegate.Font;
			cell.DetailTextLabel.TextColor = UIColor.Black;
			return cell;
		}
	}
}

