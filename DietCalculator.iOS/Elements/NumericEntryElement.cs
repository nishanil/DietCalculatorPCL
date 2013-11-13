using MonoTouch.Dialog;
using MonoTouch.UIKit;

namespace DietCalculator.iOS
{
	public class NumericEntryElement : EntryElement
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DietCalculator.iOS.NumericEntryElement"/> class.
		/// </summary>
		/// <param name="caption">Caption.</param>
		/// <param name="placeHolder">Place holder.</param>
		/// <param name="value">Value.</param>
		public NumericEntryElement (string caption, string placeHolder)
			: base(caption, placeHolder, string.Empty)
		{

			KeyboardType = UIKeyboardType.DecimalPad;
			TextAlignment = UITextAlignment.Right;
		}

		/// <Docs>Bounds for the entry to create</Docs>
		/// <returns></returns>
		/// <summary>
		/// Creates the text field.
		/// </summary>
		/// <param name="frame">Frame.</param>
		protected override UITextField CreateTextField (System.Drawing.RectangleF frame)
		{
			var textField = base.CreateTextField (frame);
			textField.Font = AppDelegate.Font;
			return textField;
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
			return cell;
		}
	}
}

