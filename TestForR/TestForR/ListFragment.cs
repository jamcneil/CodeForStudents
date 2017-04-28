using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace TestForR
{
    public class ListFragment : Fragment
    {
        public List<TestData> list { get; internal set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your fragment here
        }

        public override  View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			list = new List<TestData>();
			list.Add(new TestData { Test = "A" });
			list.Add(new TestData { Test = "B" });
			list.Add(new TestData { Test = "C" });

            View listview = inflater.Inflate(Resource.Layout.InmateList, container, false);
            ListView listviewlist = listview.FindViewById<ListView>(Resource.Id.listView1);
			//list.Adapter = new CustomListAdapter(base.Activity, Ilist);
			var adapter = new CustomListAdapter(list);
			listviewlist.Adapter = adapter;
			//list.ItemClick += OnItemListClick;

            return listview;
        }


	}
        
      
 }