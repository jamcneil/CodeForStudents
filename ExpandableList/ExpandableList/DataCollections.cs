using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExpandableList
{
	public class DataCollections : IDataCollections<Student> 
	{
		public IList<Student> CurrentCompleteList {
			get ;
			set ;
		}

		public IList<Student> CurrentList {
			get ;
			set ;
		}

		IList<Student> FirstLevelList;
		List<Student> StudentList;

		public DataCollections ()
		{
			FirstLevelList = new ObservableCollection<Student> ();
			StudentList = new List<Student> () {
				new Student{ Name = "Tom", Grade = "First" },
				new Student{ Name = "Bill", Grade = "First" },
				new Student{ Name = "Sarah", Grade = "First" },
				new Student{ Name = "Jack", Grade = "Second" },
				new Student{ Name = "Linda", Grade = "Second" },
				new Student{ Name = "Robert", Grade = "Second" },
				new Student{ Name = "Scott", Grade = "Second" },
				new Student{ Name = "Susan", Grade = "Third" },
				new Student{ Name = "George", Grade = "Third" },
				new Student{ Name = "Frank", Grade = "Third" }
			};
			IEnumerable<IGrouping<string,Student>> GroupedStudents = StudentList.GroupBy (Student => Student.Grade);
			foreach (IGrouping<string, Student> group in GroupedStudents) {
				FirstLevelList.Add (new Student{ Grade = group.Key });
			}
			CurrentList = FirstLevelList;
			CurrentCompleteList = StudentList;
		}

		public int Level (Student item)
		{
			//Given the item, get it's Level
			if (string.IsNullOrWhiteSpace (item.Name)) {
				return 1;
			} else {
				return 2;
			}
		}

		public bool MatchingCriteria(Student s, Student selected)
		{
			return s.Grade == selected.Grade;
		}
	}


}

