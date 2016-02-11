using System;

namespace Tree.Core
{
	public interface ITreeItem
	{
		string ItemToDisplay{ get; set;}
		int Level { get; set;}
		int Id { get; set;}
		int ParentId{get; set;}
	}
	public class TreeItem: ITreeItem
	{
		public string ItemToDisplay{ get; set;}
		public int Level { get; set;}
		public int Id { get; set;}
		public int ParentId{get; set;}

		public TreeItem ()
		{
		}
	}
}

