using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using System;
using SupportFragment = Android.Support.V4.App.Fragment;
using System.Collections;
using System.Collections.Generic;
using Android.Views;
using Android.Support.V4.View;
using Android.Bluetooth;
using Android.Support.V7.Widget;

namespace Navigation_View
{
	[Activity (Theme="@style/MyTheme", Label = "Conciencia Consumidor", MainLauncher = false)]
	public class MainActivity : AppCompatActivity
	{
		#region Variables 
	    Android.Support.V7.Widget.Toolbar _supporttoolbar;
		DrawerLayout _drawer;
		NavigationView _navigationview;
		private NewsFragment news;
		private TipsFragment tips;
		private TicketFragment ticket;
		private TicketJuridicoFragment ticketJuridico;
		private SeguimientoFragment seguimiento;
		private SupportFragment mCurrentFragment = new SupportFragment();
		private Stack<SupportFragment> mStackFragments;
		#endregion


		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			#region Re-defining Variables

			_supporttoolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.ToolBar);
			_supporttoolbar.SetTitle(Resource.String.boletin);
			SetSupportActionBar(_supporttoolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(false);

			_drawer = FindViewById<DrawerLayout>(Resource.Id.DrawerLayout);

			_navigationview = FindViewById<NavigationView>(Resource.Id.nav_view);

			news = new NewsFragment();
			tips = new TipsFragment();
			ticket = new TicketFragment();
			ticketJuridico = new TicketJuridicoFragment();
			seguimiento = new SeguimientoFragment();
			mStackFragments = new Stack<SupportFragment>();
		
			#endregion

			Android.Support.V4.App.FragmentTransaction tx = SupportFragmentManager.BeginTransaction();

			tx.Add(Resource.Id.layout_content, news);
			tx.Add(Resource.Id.layout_content, tips);
			tx.Add (Resource.Id.layout_content, ticket);
			tx.Add (Resource.Id.layout_content, ticketJuridico);
			tx.Add (Resource.Id.layout_content, seguimiento);
			tx.Hide(tips);
			tx.Hide (ticket);
			tx.Hide (ticketJuridico);
			tx.Hide (seguimiento);

			mCurrentFragment = news;
			tx.Commit();


			_navigationview.NavigationItemSelected += (sender, e) => {
				Android.Support.V4.App.Fragment fragment = null;
				switch (e.MenuItem.ItemId) {
				case Resource.Id.nav_news: 
					_supporttoolbar.SetTitle(Resource.String.boletin);
					fragment = new NewsFragment ();
					break;
				case Resource.Id.nav_monedero:		
					_supporttoolbar.SetTitle(Resource.String.monedero);
					fragment = new TipsFragment ();
					break;
				case Resource.Id.nav_ticket:
					_supporttoolbar.SetTitle(Resource.String.QuejasDenuncias);
					fragment = new TicketFragment ();
					break;
				case Resource.Id.nav_ticket_juridico:
					_supporttoolbar.SetTitle(Resource.String.Apoyo_Juridico);
					fragment = new TicketJuridicoFragment ();
					break;
				case Resource.Id.nav_seguimiento:
					_supporttoolbar.SetTitle(Resource.String.Seguimiento);
					fragment = new SeguimientoFragment ();
					break;
				}



				SupportFragmentManager.BeginTransaction ().Replace (Resource.Id.layout_content, fragment).Commit ();
				_drawer.CloseDrawers ();

			};
		}



		private void ShowFragment(SupportFragment fragment)
		{

			if (fragment.IsVisible) {
				return;
			}

			var trans = SupportFragmentManager.BeginTransaction ();

			fragment.View.BringToFront ();
			mCurrentFragment.View.BringToFront ();

			mCurrentFragment.View.Visibility = Android.Views.ViewStates.Invisible;
			//trans.Replace (mCurrentFragment, fragment);
			trans.Hide (mCurrentFragment);
			trans.Show (fragment);

			trans.AddToBackStack (null);
			mStackFragments.Push (mCurrentFragment);
			trans.Commit ();

			mCurrentFragment = fragment;

		}
	}
}


