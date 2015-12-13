
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
using Android.Graphics;

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

			var IniciarSesion = FindViewById<TextView> (Resource.Id.txtIniciarSesion);
			Typeface font = Typeface.CreateFromAsset (Application.Context.Assets, "Fonts/HelveticaNeue-Thin.otf");

			_supporttoolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.ToolBarRegistro);
			var ToolbarTitle = FindViewById<TextView> (Resource.Id.toolbar_titleRegister);

			ToolbarTitle.SetText (Resource.String.Registro);
			//_supporttoolbar.SetTitle(Resource.String.Registro);
			SetSupportActionBar(_supporttoolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(false);

			btnSave.SetTypeface (font, TypefaceStyle.Normal);

			_supporttoolbar.Click += (object sender, EventArgs e) => 
			{
				StartActivity (typeof(MainActivity));
			};

			IniciarSesion.Click += (object sender, EventArgs e) => 
			{
				StartActivity (typeof(IniciarSesionActivity));
			};

			btnSave.Click += (object sender, EventArgs e) => {
				btnSave.SetBackgroundColor (Color.White);
				btnSave.SetTextColor (Color.Orange);
				string strNombre = txtNombre.Text.Trim ();
				string strEmail = txtEmail.Text.Trim ();
				string strPassword = txtPassword.Text.Trim ();
				string strPassConfirm = txtPassConfirm.Text.Trim ();
				string string_key = "41f579fc-1445-4065-ab10-c06d50e724d3";

				services_911consumidor_com.COCOService cliente = new Navigation_View.services_911consumidor_com.COCOService ();

				cliente.AccountRegistration (new Navigation_View.services_911consumidor_com.UserDTO {
					FirstName = strNombre,
					Email = strEmail,
					Password = strPassword,
					Device = string.Empty
				}, string_key);

				Xamarin.Auth.Account account = new Xamarin.Auth.Account (strEmail, AccountCore.Dictionary (strNombre, strEmail, strPassword));

				AccountStore.Create (this).Save (account, "consumidor");

				new Android.Support.V7.App.AlertDialog.Builder (this)
					.SetMessage ("Su cuenta ha sido registrada.")
					.SetTitle ("ATENCIÓN")
					.Show ();

				StartActivity (typeof(MainActivity));
			};
			// Create your application here
		}
	}
}

