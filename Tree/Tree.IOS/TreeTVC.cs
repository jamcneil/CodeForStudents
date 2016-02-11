using System;
using Tree.Core;
using UIKit;
using Foundation;

namespace Tree.IOS
{
	public partial class TreeTVC : ExpandableTable.ObservableTableViewController<TreeItem>
	{
		DataCollections DC;
		Expand<TreeItem> exp;
		public TreeTVC()
		{
			DC = new DataCollections ();
			exp = new Expand<TreeItem> (DC);
			DataSource = DC.CurrentList;
			BindCellDelegate = BindTheCell;
			CreateCellDelegate = CreateTheCell;
		}

		void BindTheCell(UITableViewCell cell, object item, NSIndexPath indexPath)
		{
			TreeItem thisItem = (TreeItem)item;
			var theCell = cell as TreeCell;
			theCell.UpdateCell (thisItem);
		}

		UITableViewCell CreateTheCell(NSString reuseId)
		{
			var cell = new TreeCell(reuseId);
			return cell;
		}


		protected override void OnRowSelected (object item, NSIndexPath indexPath)
		{
			TreeItem selectedItem = (TreeItem)item;
			var newData = DC.AddNewDataForLevel (selectedItem);
			exp.ManipulateCollection (selectedItem, newData);

		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TableView.ContentInset = new UIEdgeInsets (20, 0, 0, 0);
		}
	}
}


