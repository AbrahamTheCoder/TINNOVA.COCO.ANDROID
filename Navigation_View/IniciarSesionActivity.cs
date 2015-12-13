
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
using Android.Support.V7.App;
using Android.Content.PM;
using Xamarin.Auth;
using Android.Graphics;

namespace Navigation_View
{
	[Activity (Label = "Iniciar Sesión", Theme="@style/MyTheme", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class IniciarSesionActivity : AppCompatActivity
	{
		Android.Support.V7.Widget.Toolbar _supporttoolbar;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.layout_iniciar_sesion);

			Typeface font = Typeface.CreateFromAsset (Application.Context.Assets, "Fonts/HelveticaNeue-Thin.otf");
			var btnIniciar = FindViewById<Button> (Resource.Id.btnIniciar);
			var txtContraseña = FindViewById<TextView> (Resource.Id.txtContraseñaSesion);
			var txtEmail = FindViewById<TextView> (Resource.Id.txtEmailSesion);

			btnIniciar.SetTypeface (font, TypefaceStyle.Normal);

			_supporttoolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.ToolBarSesion);
			var ToolbarTitle = FindViewById<TextView> (Resource.Id.toolbar_sesion);
			ToolbarTitle.SetText (Resource.String.Sesion);
			SetSupportActionBar(_supporttoolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(false);


			btnIniciar.Click += (object sender, EventArgs e) => {
				btnIniciar.SetBackgroundColor (Color.White);
				btnIniciar.SetTextColor (Color.Orange);
				string string_key = "41f579fc-1445-4065-ab10-c06d50e724d3";
				string UserEmail = txtEmail.Text.Trim ();
				string Password = txtContraseña.Text.Trim ();

				try {

					services_911consumidor_com.COCOService cliente = new Navigation_View.services_911consumidor_com.COCOService ();
					services_911consumidor_com.UserDTO Usuario = new Navigation_View.services_911consumidor_com.UserDTO ();

					Usuario = cliente.AccountLogin (new Navigation_View.services_911consumidor_com.UserDTO {
						Email = UserEmail,
						Password = Password
					}, string_key);

					Xamarin.Auth.Account account = new Xamarin.Auth.Account (Usuario.Email, AccountCore.Dictionary (Usuario.FirstName, Usuario.Email, Password));
					AccountStore.Create (this).Save (account, "consumidor");
					new Android.Support.V7.App.AlertDialog.Builder (this)
						.SetMessage ("Conexión Satisfactoria")
						.SetPositiveButton ("OK", delegate {
						Console.WriteLine ("OK");
					})
						.SetTitle ("ATENCIÓN")
						.Show ();

					StartActivity (typeof(MainActivity));

				} catch (Exception ex) {
					var MensajeError = ex.Message.Remove (0, 43);
					new Android.Support.V7.App.AlertDialog.Builder (this)
						.SetMessage ("Error en la conexión: " + MensajeError)
						.SetPositiveButton ("OK", delegate {
						Console.WriteLine ("OK");
					})
						.SetTitle ("ATENCIÓN")
						.Show ();
				}

			};

			// Create your application here
		}
	}
}

