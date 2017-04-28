
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TestForR
{
	public class TimeFragment : DialogFragment
	{
		public event EventHandler<DialogEventArgs> DialogClosed;
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment

			 return inflater.Inflate(Resource.Layout.TimeLayout, container, false);


		}
		public override void OnDismiss(IDialogInterface dialog)
		{
			base.OnDismiss(dialog);
			if (DialogClosed != null)
			{
				DialogClosed(this, new DialogEventArgs { ReturnValue = "Test string" });
			}
		}
	}

	public class DialogEventArgs
	{
		public string ReturnValue { get; set; }
	}
}
