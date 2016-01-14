using System;
using ExpandableList;
using UIKit;
using Foundation;


namespace ExpandTVC
{
	public class ExpandableViewController : ExpandableTable.ObservableTableViewController<Student>
	{
		DataCollections DC = new DataCollections ();
		public ExpandableViewController ()
		{
			DataSource = DC.CurrentList;
			BindCellDelegate = BindTheCell;
			CreateCellDelegate = CreateTheCell;

		}

		void BindTheCell(UITableViewCell cell, object item, NSIndexPath indexPath)
		{
			Student student = (Student)item;
			if (DC.Level(student) == 1) {  
				cell.TextLabel.Text = student.Grade;
				cell.BackgroundColor = UIColor.LightGray;
			} else {
				cell.TextLabel.Text = student.Name;
				cell.BackgroundColor = UIColor.White;
			}
		}

		UITableViewCell CreateTheCell(NSString reuseId)
		{
			var cell = new UITableViewCell(UITableViewCellStyle.Default, reuseId);
			return cell;
		}


		protected override void OnRowSelected (object item, NSIndexPath indexPath)
		{
			Student selectedItem = (Student)item;
			Expand<Student> exp = new Expand<Student> (DC);
			exp.ManipulateCollection (selectedItem);

		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
		}
	}
}

