using System;
using System.Collections;
using System.Collections.Generic;

namespace ExpandableList
{
	public interface IDataCollections<T>
	{
		IList<T> CurrentCompleteList{ get; set; }
		IList<T> CurrentList{ get; set; }
		int Level (T item);
		bool MatchingCriteria (T item, T selectedItem);

	}
	public class Expand<T>
	{
		IDataCollections<T> dc;
		public Expand (IDataCollections<T> dc)
		{
			this.dc = dc;
		}
		//For multiple levels, get the level of the clicked item and change the logic based on the level passed in
		public void ManipulateCollection (T selectedItem) 
		{
			if (dc.Level(selectedItem) == 1) {  // this is a level 1 cell 
				var index = 1;
				foreach(T s in dc.CurrentCompleteList)
				{					
					if (dc.MatchingCriteria(s, selectedItem)) {
						if(dc.Level(selectedItem) != 1 && dc.CurrentList.Contains(s))//prevent duplicates if they click more than once 
							return;
						if (dc.CurrentList.IndexOf(selectedItem) >= dc.CurrentList.Count) {
							dc.CurrentList.Add (s);
						} else {
							dc.CurrentList.Insert (dc.CurrentList.IndexOf(selectedItem) + index, s);
							index++;
						}
					} else {
						dc.CurrentList.Remove (s);
					}
				}
			}
		}
	}
}

