
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Dalvik.SystemInterop;
using Xamarin.Auth;
using Android.Graphics;
using Android.Content.Res;

namespace Navigation_View
{
	public class TipsFragment : Android.Support.V4.App.Fragment
	{


		private NewsFragment news;
		private TicketJuridicoFragment TicketJuridico;
		private SeguimientoFragment seguimiento;
		private FrameLayout mFragment4Container;
		private SupportFragment mCurrentFragment = new SupportFragment();
		private Stack<SupportFragment> mStackFragments;
		public static string Email;
		public static string Nombre;
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
			ViewGroup root = (ViewGroup)inflater.Inflate (Resource.Layout.layout_main,null);
			//return base.OnCreateView (inflater, container, savedInstanceState);

			mFragment4Container = root.FindViewById<FrameLayout> (Resource.Id.layout_contentMain);

			var btnBoletin = root.FindViewById<Button> (Resource.Id.btnBoletin);
			var btnTicket = root.FindViewById<Button> (Resource.Id.btnAsesoria);
			var btnSeguimiento = root.FindViewById<Button> (Resource.Id.btnSeguimiento);

			Typeface font = Typeface.CreateFromAsset (Application.Context.Assets, "Fonts/HelveticaNeue-Thin.otf");
			btnSeguimiento.SetTypeface (font, TypefaceStyle.Normal);
			btnBoletin.SetTypeface (font, TypefaceStyle.Normal);
			btnTicket.SetTypeface (font, TypefaceStyle.Normal);

			var ToolBar = Activity.FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.ToolBar);
			var ToolBarTitle = Activity.FindViewById<TextView> (Resource.Id.toolbar_title);
			ToolBar.Visibility = ViewStates.Gone;
			ToolBar.SetTitle (Resource.String.app_name);

			news = new NewsFragment ();
			TicketJuridico = new TicketJuridicoFragment ();
			seguimiento = new SeguimientoFragment ();
			mStackFragments = new Stack<SupportFragment>();

			var trans = Activity.SupportFragmentManager.BeginTransaction ();
			trans.Add (mFragment4Container.Id, news, "News");
			trans.Add (mFragment4Container.Id, TicketJuridico, "Juridico");
			trans.Add (mFragment4Container.Id, seguimiento, "Seguimiento");
			trans.Hide (news);
			trans.Hide (TicketJuridico);
			trans.Hide (seguimiento);
			mCurrentFragment = this;
			trans.Commit ();



			btnBoletin.Click += (object sender, EventArgs e) => {
				ToolBar.Visibility = ViewStates.Visible;
				//ToolBar.SetTitle (Resource.String.boletin);
				ToolBarTitle.SetText (Resource.String.boletin);
				Android.Support.V4.App.Fragment fragment = null;
				fragment = new NewsFragment ();
				Activity.SupportFragmentManager.BeginTransaction ().Replace (Resource.Id.layout_content, fragment).Commit ();
			};

			btnTicket.Click += (object sender, EventArgs e) => {

				var accounts = AccountStore.Create (root.Context).FindAccountsForService ("consumidor");



				if (accounts.Count () == 0) {
					Intent intentRegistro = new Intent (this.Context, typeof(RegisterActivity));
					this.Context.StartActivity (intentRegistro);
				} else {
					foreach (var account in accounts) {
						Email = account.Properties ["Email"];
						Nombre = account.Properties["FName"];
					}
					ToolBar.Visibility = ViewStates.Visible;
					ToolBarTitle.SetText (Resource.String.QuejasDenuncias);
					Android.Support.V4.App.Fragment fragment = null;
					fragment = new TicketJuridicoFragment ();
					Activity.SupportFragmentManager.BeginTransaction ().Replace (Resource.Id.layout_content, fragment).Commit ();
				}
			};

			btnSeguimiento.Click += (object sender, EventArgs e) => 
			{
				ToolBar.Visibility = ViewStates.Visible;
				ToolBarTitle.SetText (Resource.String.Seguimiento);
				Android.Support.V4.App.Fragment fragment = null;
				fragment = new SeguimientoFragment();
				Activity.SupportFragmentManager.BeginTransaction ().Replace (Resource.Id.layout_content, fragment).Commit ();
			};

			return root;
		}
	}
}

