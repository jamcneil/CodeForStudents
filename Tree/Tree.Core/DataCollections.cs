using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tree.Core
{
	public class DataCollections : IDataCollections<TreeItem>
	{
		#region IDataCollections implementation

		public System.Collections.Generic.IList<TreeItem> CurrentList {
			get;
			set;
		}

		#endregion

		public DataCollections ()
		{
			CurrentList = GetFirstLevelData ();
		}

		// simulate getting first section of data  - will most likely be from a web service
		ObservableCollection<TreeItem> GetFirstLevelData ()
		{
			return new ObservableCollection<TreeItem> () {
				new TreeItem{ Id = 1, Level = 1, ItemToDisplay = "One", ParentId = 0 },
				new TreeItem{ Id = 2, Level = 1, ItemToDisplay = "Two", ParentId = 0 },
				new TreeItem{ Id = 3, Level = 1, ItemToDisplay = "Three", ParentId = 0 },
				new TreeItem{ Id = 4, Level = 1, ItemToDisplay = "Four", ParentId = 0 },
			};
		}

		// simulate getting new section of data  - will most likely be from a web service
		public List<TreeItem> AddNewDataForLevel(TreeItem selected)
		{
			int clickedLevel = selected.Level;
			int id = selected.Id;
			List<TreeItem> newData = null;

			switch (clickedLevel) {
			case 1:// Level 1 item clicked
				switch (id) {
				case 1:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 5, Level = 2, ItemToDisplay = "A", ParentId = 1 },
						new TreeItem{ Id = 6, Level = 2, ItemToDisplay = "B", ParentId = 1 },
						new TreeItem{ Id = 7, Level = 2, ItemToDisplay = "C", ParentId = 1 },
					};
					break;
				case 2:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 8, Level = 2, ItemToDisplay = "A", ParentId = 1 },
						new TreeItem{ Id = 9, Level = 2, ItemToDisplay = "B", ParentId = 1 },
					};
					break;
				case 3:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 10, Level = 2, ItemToDisplay = "A", ParentId = 1 },
						new TreeItem{ Id = 11, Level = 2, ItemToDisplay = "B", ParentId = 1 },
						new TreeItem{ Id = 12, Level = 2, ItemToDisplay = "C", ParentId = 1 },
					};
					break;
				case 4:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 13, Level = 2, ItemToDisplay = "A", ParentId = 1 },
						new TreeItem{ Id = 14, Level = 2, ItemToDisplay = "B", ParentId = 1 },
					};
					break;
				}
				break;
			case 2: //Level 2 item clicked
				switch (id) {
				case 5:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 15, Level = 3, ItemToDisplay = "1", ParentId = 5 },
						new TreeItem{ Id = 16, Level = 3, ItemToDisplay = "2", ParentId = 5 },
						new TreeItem{ Id = 17, Level = 3, ItemToDisplay = "3", ParentId = 5 },
					};
					break;
				case 6:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 18, Level = 3, ItemToDisplay = "1", ParentId = 6 },
						new TreeItem{ Id = 19, Level = 3, ItemToDisplay = "2", ParentId = 6 },
						new TreeItem{ Id = 20, Level = 3, ItemToDisplay = "3", ParentId = 6 },
					};
					break;
				case 7:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 21, Level = 3, ItemToDisplay = "1", ParentId = 7 },
						new TreeItem{ Id = 22, Level = 3, ItemToDisplay = "2", ParentId = 7 },
						new TreeItem{ Id = 23, Level = 3, ItemToDisplay = "3", ParentId = 7 },
					};
					break;
				case 8:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 24, Level = 3, ItemToDisplay = "1", ParentId = 8 },
						new TreeItem{ Id = 25, Level = 3, ItemToDisplay = "2", ParentId = 8 },
						new TreeItem{ Id = 26, Level = 3, ItemToDisplay = "3", ParentId = 8 },
					};
					break;
				case 9:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 27, Level = 3, ItemToDisplay = "1", ParentId = 9 },
						new TreeItem{ Id = 28, Level = 3, ItemToDisplay = "2", ParentId = 9 },
						new TreeItem{ Id = 29, Level = 3, ItemToDisplay = "3", ParentId = 9 },
					};
					break;
				case 10:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 30, Level = 3, ItemToDisplay = "1", ParentId = 10 },
						new TreeItem{ Id = 31, Level = 3, ItemToDisplay = "2", ParentId = 10 },
						new TreeItem{ Id = 32, Level = 3, ItemToDisplay = "3", ParentId = 10 },
					};
					break;
				case 11:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 33, Level = 3, ItemToDisplay = "1", ParentId = 11 },
						new TreeItem{ Id = 34, Level = 3, ItemToDisplay = "2", ParentId = 11 },
						new TreeItem{ Id = 35, Level = 3, ItemToDisplay = "3", ParentId = 11 },
					};
					break;
				case 12:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 36, Level = 3, ItemToDisplay = "1", ParentId = 12 },
						new TreeItem{ Id = 37, Level = 3, ItemToDisplay = "2", ParentId = 12 },
						new TreeItem{ Id = 38, Level = 3, ItemToDisplay = "3", ParentId = 12 },
					};
					break;
				case 13:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 39, Level = 3, ItemToDisplay = "1", ParentId = 13 },
						new TreeItem{ Id = 40, Level = 3, ItemToDisplay = "2", ParentId = 13 },
						new TreeItem{ Id = 41, Level = 3, ItemToDisplay = "3", ParentId = 13 },
					};
					break;
				case 14:
					newData = new List<TreeItem> () {
						new TreeItem{ Id = 42, Level = 3, ItemToDisplay = "1", ParentId = 14 },
						new TreeItem{ Id = 43, Level = 3, ItemToDisplay = "2", ParentId = 14 },
						new TreeItem{ Id = 44, Level = 3, ItemToDisplay = "3", ParentId = 14 },
					};
					break;
				}
				break;
			}
			return newData;
		}
	}
}

