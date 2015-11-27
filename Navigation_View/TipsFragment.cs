
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

namespace Navigation_View
{
	public class TipsFragment : Android.Support.V4.App.Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public static Android.Support.V4.App.Fragment newInstance(Context context)
		{
			TipsFragment tips = new TipsFragment ();
			return tips;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			ViewGroup root = (ViewGroup)inflater.Inflate (Resource.Layout.layout_tips,null);
			//return base.OnCreateView (inflater, container, savedInstanceState);
			return root;
		}
	}
}

