
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
using Android.Content.PM;
using Android.Accounts;
using Xamarin.Auth;
using Android.Support.V7.App;

namespace Navigation_View
{
	[Activity (Label = "Registro", Theme="@style/MyTheme", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class RegisterActivity : AppCompatActivity
	{
		Android.Support.V7.Widget.Toolbar _supporttoolbar;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.layout_register);

			var btnSave = FindViewById<Button> (Resource.Id.btnGuardar);
			var txtNombre = FindViewById<TextView> (Resource.Id.txtNombreCompleto);
			var txtEmail = FindViewById<TextView> (Resource.Id.txtEmailRegistro);
			var txtPassword = FindViewById<TextView> (Resource.Id.txtContraseña);
			var txtPassConfirm = FindViewById<TextView> (Resource.Id.txtContraseñaConfirmar);

			_supporttoolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.ToolBarRegistro);
			_supporttoolbar.SetTitle(Resource.String.Registro);
			SetSupportActionBar(_supporttoolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(false);

			btnSave.Click += (object sender, EventArgs e) => 
			{
				string strNombre = txtNombre.Text.Trim ();
				string strEmail = txtEmail.Text.Trim ();
				string strPassword = txtPassword.Text.Trim ();
				string strPassConfirm = txtPassConfirm.Text.Trim ();

				Xamarin.Auth.Account account = new Xamarin.Auth.Account(strEmail,AccountCore.Dictionary (strNombre,strEmail,strPassword));

				AccountStore.Create (this).Save (account,"consumidor");
				StartActivity (typeof(MainActivity));
			};
			// Create your application here
		}
	}
}

