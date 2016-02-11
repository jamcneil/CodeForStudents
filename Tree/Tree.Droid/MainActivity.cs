using Android.App;
using Android.Widget;
using Android.OS;
using Tree.Core;

namespace Tree.Droid
{
	[Activity (Label = "Tree.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		DataCollections DC = new DataCollections();
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			var lv = FindViewById<ListView> (Resource.Id.treeList);
			lv.ItemClick += OnItemClick;

			var adapter = new GalaSoft.MvvmLight.Helpers.ObservableAdapter<TreeItem> ();
			adapter.DataSource = DC.CurrentList;
			adapter.GetTemplateDelegate = GetTheView;
			lv.Adapter = adapter;
		}

		void OnItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			TreeItem selectedItem = DC.CurrentList[e.Position];
			var newData = DC.AddNewDataForLevel (selectedItem);
			var exp = new Expand<TreeItem> (DC);
			exp.ManipulateCollection (selectedItem, newData);
		}

		Android.Views.View GetTheView (int position, TreeItem item, Android.Views.View convertView)
		{
			var view = convertView;
			if (view == null) {
				view = LayoutInflater.Inflate (Resource.Layout.TreeCell, null);
				TextView level1TV = view.FindViewById<TextView> (Resource.Id.level1Text);
				TextView level2TV = view.FindViewById<TextView> (Resource.Id.level2Text);
				TextView level3TV = view.FindViewById<TextView> (Resource.Id.level3Text);
				view.Tag = new ViewHolder (){ Level1TV = level1TV, Level2TV = level2TV, Level3TV = level3TV }; 
			}
			var holder = (ViewHolder)view.Tag;
			//set up cell depending on level
			switch (item.Level) {
			case 1:
				holder.Level1TV.Text = item.ItemToDisplay;
				holder.Level2TV.Text = "      ";
				holder.Level3TV.Text = "      ";
				break;
			case 2:
				holder.Level1TV.Text = "      ";
				holder.Level2TV.Text = item.ItemToDisplay;
				holder.Level3TV.Text = "      ";
				break;
			case 3:
				holder.Level1TV.Text = "      ";
				holder.Level2TV.Text = "      ";
				holder.Level3TV.Text = item.ItemToDisplay;
				break;
			}
			return view;
		}
	}
	public class ViewHolder : Java.Lang.Object
	{
		public TextView Level1TV { get; set; }
		public TextView Level2TV { get; set; }
		public TextView Level3TV { get; set; }
	}
}


