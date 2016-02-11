using System;
using System.Collections.Generic;
using System.Collections;

namespace Tree.Core
{
	public interface IDataCollections<T>
	{
		IList<T> CurrentList{ get; set; }
	}

	public class Expand<T> where T : class, ITreeItem
	{
		IDataCollections<T> dc;

		public Expand (IDataCollections<T> dc)
		{
			this.dc = dc;
		}
		//For multiple levels, get the level of the clicked item and change the logic based on the level 
		public void ManipulateCollection (T selectedItem, List<T> newData)
		{
			int level = selectedItem.Level;
			int parentId = selectedItem.ParentId;
			IList<T> tempList = new List<T>();

			if (level == 1) {
				//clear the list of previous selection's children
				foreach (T item in dc.CurrentList) {
						if (item.Level == 2 || item.Level == 3) {
							tempList.Add (item); // add to tempList to remove after we exit the loop
						}
				}
				foreach (T item in tempList) {
					dc.CurrentList.Remove (item);
				}
				tempList.Clear ();

				//add new items at the right index
				int index = dc.CurrentList.IndexOf(selectedItem);
				index++;
				AddData (newData, ref index);
			} else if (level == 2) {
				//clear the list of previos level 3 items
				foreach (T item in dc.CurrentList) {
					if (item.Level == 3) {
						tempList.Add (item);
					}
				}
				foreach (T item in tempList) {
					dc.CurrentList.Remove (item);
				}
				tempList.Clear ();

				//add new items at the right index
				int index = dc.CurrentList.IndexOf(selectedItem);
				index++;
				AddData (newData, ref index);
			}
		}

		void AddData (List<T> newData, ref int index)
		{
			foreach (T item in newData) {
				if (dc.CurrentList.Count <= index) {  // we clicked the last item in the list
					dc.CurrentList.Add (item);
				}
				else {
					dc.CurrentList.Insert (index, item);
				}
				index++;
			}
		}
	}
}

