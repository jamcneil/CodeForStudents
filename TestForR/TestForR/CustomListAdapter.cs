using System;
using System.Collections.Generic;
using Android.App;
using Android.Database;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace TestForR
{
	class CustomListAdapter : BaseAdapter<TestData>
	{
		//Activity activity;
		//FragmentManager fm;
		IList<TestData> ilist;

		public CustomListAdapter(List<TestData> ilist)
		{
			//this.activity = activity;
			//this.fm = fm;
			this.ilist = ilist;
		}

		public override TestData this[int position]
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override int Count
		{
			get
			{
				return ilist.Count;
			}
		}


		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.list_item, parent, false);
			var text = view.FindViewById<TextView>(Resource.Id.empId);
			var autoText = view.FindViewById<AutoCompleteTextView>(Resource.Id.AutoCompleteInput);

			TestData item = ilist[position];
			text.Text = item.Test;
			var autoCompleteOptions = new string[] { "Hello", "Hey", "Heja", "Hi", "Hola", "Bonjour", "Gday", "Goodbye", "Sayonara", "Farewell", "Adios" };
			ArrayAdapter autoCompleteAdapter = new ArrayAdapter(view.Context, Android.Resource.Layout.SimpleDropDownItem1Line, autoCompleteOptions);
			autoText.Adapter = autoCompleteAdapter;

			var timetext = view.FindViewById<TextView>(Resource.Id.timeinput);
			ImageView image = view.FindViewById<ImageView>(Resource.Id.demoImageView);
			image.Click += (sender, e) =>
			{
				TimeFragment userDialog = new TimeFragment();
				userDialog.DialogClosed += (s, e2) =>
				{
					string returnValue = e2.ReturnValue;
					timetext.Text = returnValue;
				};
				userDialog.Show(fm, "TimeFragment");

			};

			return view;
		}


	}
}