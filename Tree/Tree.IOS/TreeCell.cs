using System;
using Tree.Core;
using Foundation;
using UIKit;

namespace Tree.IOS
{
	public class TreeCell : UITableViewCell
	{
		UILabel Level1Label, Level2Label, Level3Label;

		public TreeCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			Level1Label = new UILabel () {
				TextColor = UIColor.Green
			};
			Level2Label = new UILabel () {
				TextColor = UIColor.Yellow
			};
			Level3Label = new UILabel () {
				TextColor = UIColor.Red
			};
			ContentView.AddSubviews (new UIView[] { Level1Label, Level2Label, Level3Label });
		}

		public void UpdateCell(TreeItem item)
		{
			switch (item.Level) {
			case 1:
				Level1Label.Text = item.ItemToDisplay;
				Level2Label.Text = "";
				Level3Label.Text = "";
				break;
			case 2:
				Level1Label.Text = "";
				Level2Label.Text = item.ItemToDisplay;
				Level3Label.Text = "";
				break;
			case 3:
				Level1Label.Text = "";
				Level2Label.Text = "";
				Level3Label.Text = item.ItemToDisplay;
				break;
			}
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			Level1Label.Frame = new CoreGraphics.CGRect (5, 4, 80, 25);
			Level2Label.Frame = new CoreGraphics.CGRect (85, 4, 80, 25);
			Level3Label.Frame = new CoreGraphics.CGRect (170, 4, 80, 25);	
		}

	}
}
