using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using ExpandableList;
using System.Collections.ObjectModel;
using Android.Views;

namespace ExpandListView
{
	[Activity (Label = "ExpandListView", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		DataCollections DC = new DataCollections ();
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var lv = FindViewById<ListView> (Resource.Id.studentList);
			lv.ItemClick += OnItemClick;

			var adapter = new GalaSoft.MvvmLight.Helpers.ObservableAdapter<Student> ();
			adapter.DataSource = DC.CurrentList;
			adapter.GetTemplateDelegate = GetTheView;
			lv.Adapter = adapter;

		}

		void OnItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			//Add the clicked grade students to the CurrentList
			Student clickedRow = DC.CurrentList [e.Position];
			Expand<Student> exp = new Expand<Student> (DC);
			exp.ManipulateCollection (clickedRow);
		}

		public View GetTheView (int position, Student s, View convertView)
		{
			var view = convertView;
			if (convertView == null) {
				view = LayoutInflater.Inflate (Resource.Layout.StudentRow, FindViewById<ListView> (Resource.Id.studentList), false);
				var tv = view.FindViewById<TextView> (Resource.Id.textView);
				view.Tag = new ViewHolder (){ TV = tv };
			}

			var holder = (ViewHolder)view.Tag;
			//set up the cell depending on if it is first level or second level
			if (DC.Level(s) == 1) {  //FirstLevel 
				holder.TV.Text = s.Grade;
				holder.TV.Gravity = GravityFlags.Start;
			} else {  //SecondLevel
				holder.TV.Text = s.Name;
				holder.TV.Gravity = GravityFlags.CenterHorizontal;
			}

			return view;
		}
	}

	public class ViewHolder : Java.Lang.Object
	{
		public TextView TV { get; set; }
	}

}


