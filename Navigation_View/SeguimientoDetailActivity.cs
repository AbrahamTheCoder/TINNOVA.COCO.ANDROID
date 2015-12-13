
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
using Android.Support.V7.Widget;
using Java.Util.Zip;
using System.Security.Cryptography;
using Android.Content.PM;
using Android.Graphics;

namespace Navigation_View
{
	[Activity (Label = "Seguimiento", Theme="@style/MyTheme", ScreenOrientation = ScreenOrientation.Portrait)]			
	public class SeguimientoDetailActivity : AppCompatActivity
	{


		Android.Support.V7.Widget.Toolbar _supporttoolbar;
		protected override void OnCreate (Bundle savedInstanceState)
		{

			Bundle bundle = Intent.Extras;

			var TicketListDetails = Seguimiento_Adapter.DetallesTicket;
			var TicketID = Convert.ToInt32 (Intent.GetStringExtra ("TicketID").ToString ());

			List<TicketDetail> ListResults = TicketListDetails.FindAll (x => x.TicketID == TicketID);

			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.layout_detalle);


			_supporttoolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.ToolBarSeguimientoDetalle);
			//_supporttoolbar.SetTitle(Resource.String.Seguimiento);

			var ToolbarTitle = FindViewById<TextView> (Resource.Id.toolbar_titleDetalle);
			var ToolbarBack = FindViewById<ImageView> (Resource.Id.toolbar_backSeg);

			ToolbarTitle.SetText (Resource.String.Seguimiento);
			ToolbarBack.SetImageResource (Resource.Drawable.Back48x48);

			SetSupportActionBar(_supporttoolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(false);

			var listView = FindViewById<ListView> (Resource.Id.ListDetalle);

			listView.Adapter = new SeguimientoDetail_Adapter (ListResults, this);
			Typeface font = Typeface.CreateFromAsset (Application.Context.Assets, "Fonts/HelveticaNeue-Thin.otf");

			var btnEnviar = FindViewById<Button> (Resource.Id.btnEnviarComentario);
			var txtComentario = FindViewById<EditText> (Resource.Id.txtNewComment);


			//btnEnviar.SetBackgroundResource (Resource.Drawable.selectors);
			btnEnviar.SetTypeface (font,TypefaceStyle.Normal);
			_supporttoolbar.Click += (object sender, EventArgs e) => 
			{
				StartActivity (typeof(MainActivity));
			};


			ToolbarBack.Click += (object sender, EventArgs e) => 
			{
				base.OnBackPressed ();
			};
				

			btnEnviar.Click += (object sender, EventArgs e) => {
				btnEnviar.SetBackgroundColor (Color.White);
				btnEnviar.SetTextColor (Color.Orange);
				var string_key = "41f579fc-1445-4065-ab10-c06d50e724d3";
				//cocoservices.tinnova.mx.COCOService servicio = new Navigation_View.cocoservices.tinnova.mx.COCOService ();
				services_911consumidor_com.COCOService servicio = new Navigation_View.services_911consumidor_com.COCOService ();
				try {

					var resultado = 0;
					resultado = servicio.CreateTicketDetail (new Navigation_View.services_911consumidor_com.TicketDetailDTO {
						TIC_ID = Convert.ToInt32 (TicketID.ToString ()),
						Message = txtComentario.Text.Trim (),
						DetailDate = DateTime.Now,
						Subject = "Mensaje Consumidor",
						Status = new Navigation_View.services_911consumidor_com.StatusDTO {
							Id = 12,
							OBJ_ID = 5
						},
						Agent = new Navigation_View.services_911consumidor_com.UserDTO {
							UserId = string.Empty
						}
					}, string_key);

					if (resultado != 0) {
						new Android.Support.V7.App.AlertDialog.Builder (this)
							.SetMessage ("Su comentario ha sido registrado. Gracias")
							.SetPositiveButton ("OK", delegate {
							Console.WriteLine ("OK");
						})
							.SetTitle ("ATENCIÓN")
							.Show ();
					}

					
				} catch (Exception ex) {
					new Android.Support.V7.App.AlertDialog.Builder (this)
						.SetMessage ("Ocurrio un error: " + ex.Message.ToString ())
						.SetTitle ("ATENCIÓN")
						.SetPositiveButton ("OK", delegate {
						Console.WriteLine ("OK");
					})
						.Show ();
				} finally {
					txtComentario.Text = "";
				}

				StartActivity (typeof(MainActivity));

			};

		}
	}
}

