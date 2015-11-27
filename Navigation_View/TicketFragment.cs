
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
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Graphics.Drawables;

namespace Navigation_View
{
	public class TicketFragment : Android.Support.V4.App.Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}


		public static Android.Support.V4.App.Fragment newInstance(Context context)
		{
			TicketFragment ticket = new TicketFragment ();
			return ticket;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			ViewGroup root = (ViewGroup)inflater.Inflate (Resource.Layout.layout_tickets,null);

			cocoservices.tinnova.mx.COCOService cliente = new Navigation_View.cocoservices.tinnova.mx.COCOService ();

			string string_key = "41f579fc-1445-4065-ab10-c06d50e724d3";


			Button btnRegistrar = root.FindViewById<Button> (Resource.Id.btnAceptar);

			btnRegistrar.Click += (object sender, EventArgs e) => {
				string strError = "";
				EditText txtNombre = root.FindViewById<EditText> (Resource.Id.txtNombre);
				//EditText txtApellido = root.FindViewById<EditText>(Resource.Id.txtApellido);
				EditText txtCorreo = root.FindViewById<EditText> (Resource.Id.txtEmail);
				EditText txtTelefono = root.FindViewById<EditText> (Resource.Id.txtPhone);
				Spinner ddEstado = root.FindViewById<Spinner> (Resource.Id.ddlEstado);
				EditText txtCiudad = root.FindViewById<EditText> (Resource.Id.txtCiudad);
				//EditText txtCP = root.FindViewById<EditText>(Resource.Id.txtCP);
				EditText txtNota = root.FindViewById<EditText> (Resource.Id.txtNota);
				Drawable icon_error = Resources.GetDrawable (Resource.Drawable.Error128);
				//cliente.ChannelFactory = 

				try {

					Ticket ticket = new Ticket ();

					if (!string.IsNullOrEmpty (txtNombre.Text.Trim ()))
						ticket.Nombre = txtNombre.Text.Trim ();
					else {
						//throw new Exception("Debe escribir un Nombre");
						txtNombre.SetError ("Es requerido un Nombre ", icon_error);
						strError += "Nombre";
					}
					if (!string.IsNullOrEmpty (txtCorreo.Text.Trim ()))
						ticket.Email = txtCorreo.Text.Trim ();
					else {
						txtCorreo.SetError ("Es requerido un Correo Electronico ", icon_error);
						strError += "Correo Electronico";
					}
					if (!string.IsNullOrEmpty (txtTelefono.Text.Trim ()))
						ticket.Telefono = txtTelefono.Text.Trim ();
					else {
						txtTelefono.SetError ("Es requerido un Telefono ", icon_error);
						strError += "Telefono";
					}
					if (!string.IsNullOrEmpty (txtNota.Text.Trim ()))
						ticket.Nota = txtNota.Text.Trim ();
					else {
						txtNota.SetError ("Es requerido un Comentario ", icon_error);
						strError += "Comentario";
					}
					
					ticket.Ciudad = txtCiudad.Text.Trim ();
					ticket.Estado = ddEstado.SelectedItem.ToString ();

					if (string.IsNullOrEmpty (strError)) {
						var resultado = cliente.CreateTicket (
							                new Navigation_View.cocoservices.tinnova.mx.TicketDTO {	Client = new Navigation_View.cocoservices.tinnova.mx.UserDTO {	FirstName = ticket.Nombre,
									LastName = string.Empty,
									Email = ticket.Email,
									Phone = ticket.Telefono,
									PostalCode = string.Empty,
									AddressCity = ticket.Ciudad,
									AddressState = ticket.Estado,
								},
								Status = new Navigation_View.cocoservices.tinnova.mx.StatusDTO {	
									OBJ_ID = 2, 
									Id = 3
								}, 
								Type = new Navigation_View.cocoservices.tinnova.mx.TypeDTO { 
									ObjId = 2, 
									Id = 1
								}, 
								User = new Navigation_View.cocoservices.tinnova.mx.UserDTO
								{ Id = 1 },
								TicketDetail = new Navigation_View.cocoservices.tinnova.mx.TicketDetailDTO[] {
									new Navigation_View.cocoservices.tinnova.mx.TicketDetailDTO {
										DetailDate = DateTime.Now,
										Subject = "Contacto Consumidor",
										Status = new Navigation_View.cocoservices.tinnova.mx.StatusDTO {
											OBJ_ID = 2,
											Id = 3
										},
										Message = string.Empty,
										Agent = new Navigation_View.cocoservices.tinnova.mx.UserDTO {
											UserId = string.Empty
										}
									}
								},
								Notes = ticket.Nota
							}, string_key);
						
						if (resultado != 0) {
							new AlertDialog.Builder (root.Context)
								.SetMessage ("Muchas gracias por ponerte en contacto con 911 CONSUMIDOR, en breve recibirás una respuesta a tu caso.")
								.SetTitle ("ATENCIÓN")
								.Show ();
						}
					}
						
					
				} catch (Exception ex) {
					new AlertDialog.Builder (root.Context)
						.SetMessage ("Ocurrio un error: " + ex.Message.ToString ())
						.SetTitle ("ATENCIÓN")
						.Show ();
				} finally {
					//txtApellido.Text="";
					txtNombre.Text = "";
					txtNota.Text = "";
					txtCiudad.Text = "";
					txtCorreo.Text = "";
					txtTelefono.Text = "";
					//ddEstado.SelectedItemPosition = -1;

				}
			};


			return root;
		}
	}
}

