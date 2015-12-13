
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
using System.Threading;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Gcm.Client;
using Android.Util;
using Android.Content.PM;
using Xamarin.Auth;

namespace Navigation_View
{
	[Activity (Label = "Conciencia del Consumidor", MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true)]			
	public class SplashScreen : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			Thread.Sleep (1000);
			RegisterWithGCM ();
			StartActivity (typeof(MainActivity));
			// Create your application here

		}

		private void RegisterWithGCM()
		{
			// Check to ensure everything's set up right
			GcmClient.CheckDevice(this);
			GcmClient.CheckManifest(this);

			// Register for push notifications
			Log.Info("MainActivity", "Registering...");
			GcmClient.Register(this, Constans.SenderID);
		}
	}
}

