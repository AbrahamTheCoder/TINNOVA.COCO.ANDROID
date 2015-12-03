using System;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.Widget;
using Android.Views;
using System.IO.MemoryMappedFiles;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;
using Navigation_View.cocoservices.tinnova.mx;
using Android.OS;
using System.Collections;


namespace Navigation_View
{
	public class Seguimiento_Adapter : RecyclerView.Adapter
	{


		private Context mContext;
		private RecyclerView mRecyclerView;
		private List<Ticket> mTickets;
		private List<TicketDetail> mTicketDetails;

		public static List<TicketDetail> DetallesTicket;

		public Seguimiento_Adapter (List<Ticket> ticket, List<TicketDetail> ticketDetail, RecyclerView recycler, Context context)
		{
			mTickets = ticket;
			mTicketDetails = ticketDetail;
			mContext = context;
			mRecyclerView = recycler;
		}

		public class SeguimientoAdapterWrapper : RecyclerView.ViewHolder
		{
			public View mView { get; set; }
			public TextView FirstLastName { get; set;}
			public TextView EmailTicket { get; set;}
			public TextView CPTicket { get; set;}
			public TextView OrdenTicket { get; set; }
			public TextView FechaTicket { get; set; }
			public TextView CorreoTicket { get; set; }
			public TextView TipoTicket { get; set; }
			public TextView NotaTicket { get; set; }
			public TextView StatusTicket { get; set;}
			public Button DetalleTicket { get; set; }
			public ImageView Semaforo { get; set;}

			public SeguimientoAdapterWrapper(View view) : base(view)
			{
				mView = view;
			}
		}

		public override int GetItemViewType(int position)
		{

			return Resource.Layout.layout_seguimientoGroup;
		}

		#region implemented abstract members of Adapter
		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			SeguimientoAdapterWrapper MyHolder = holder as SeguimientoAdapterWrapper;
			var strFolio = string.Empty;
			strFolio = mTickets [position].TicketID.ToString ();
			while (strFolio.Length < 5) {
				strFolio = "0" + strFolio;
			}

			MyHolder.OrdenTicket.Text = "Denuncia Folio: " + strFolio.Trim ();
			MyHolder.FechaTicket.Text = "Fecha: " + mTickets [position].Fecha.ToString ();
			//MyHolder.CorreoTicket.Text = mTickets[position].Email;
			MyHolder.StatusTicket.Text = "" + mTickets [position].Estatus;
			//MyHolder.NotaTicket.Text = mTicketDetails [position].Mensaje;
			MyHolder.FirstLastName.Text = mTickets [position].Nombre + " " + mTickets [position].Apellido;

			if (mTickets [position].Estatus == "Cerrado") {
				MyHolder.Semaforo.SetImageResource (Resource.Drawable.greencerrado);
			} else if (mTickets [position].Estatus == "Seguimiento") {
				MyHolder.Semaforo.SetImageResource (Resource.Drawable.yellowSeguimiento);
			} else if (mTickets [position].Estatus == "Nuevo"){
				MyHolder.Semaforo.SetImageResource (Resource.Drawable.RedAbierta);
			}

			MyHolder.DetalleTicket.Click += (object sender, EventArgs e) => {
				Intent intentDetailsTicket = new Intent (this.mContext, typeof(SeguimientoDetailActivity));
				intentDetailsTicket.PutExtra ("TicketID", mTickets [position].TicketID.ToString ());
				int TicketID = Convert.ToInt32 (mTickets [position].TicketID.ToString ());
				//List<TicketDetail> ListResults = mTicketDetails.FindAll (x => x.TicketID == TicketID);

				//ArrayList<TicketDetail> ListArray = new ArrayList<TicketDetail>();
//				Bundle bundle = new Bundle();
//				bundle.PutParcelable("TicketDetalle",ListResults);
				//intentDetailsTicket.PutParcelableArrayListExtra ("TicketDetalle",ListResults);
				DetallesTicket = mTicketDetails;
				this.mContext.StartActivity (intentDetailsTicket);
			};

		}
		public override RecyclerView.ViewHolder OnCreateViewHolder (Android.Views.ViewGroup parent, int viewType)
		{
			View row = LayoutInflater.From (mContext).Inflate (Resource.Layout.layout_seguimientoGroup, parent, false);

			TextView txtOrdenTicket = row.FindViewById<TextView> (Resource.Id.txtOrderTicket);
			TextView txtFechaTicket = row.FindViewById<TextView> (Resource.Id.txtFechaTicket);
			//TextView txtCorreoTicket = row.FindViewById<TextView> (Resource.Id.txtCorreoTicket);
			TextView txtStatusTicket = row.FindViewById<TextView> (Resource.Id.txtStatusTicket);
			//TextView txtNotaTicket = row.FindViewById<TextView> (Resource.Id.txtNotaTicket);
			TextView txtNombreApellido = row.FindViewById<TextView> (Resource.Id.txtNombreTicket);
			//TextView txtEmail = row.FindViewById<TextView> (Resource.Id.txtCorreoTicket);
			ImageView imgSemaforo = row.FindViewById<ImageView> (Resource.Id.img_semaforo);
			Button btnDetalle = row.FindViewById<Button> (Resource.Id.btnDetalleSeguimiento);

			SeguimientoAdapterWrapper view = new SeguimientoAdapterWrapper (row) {
				OrdenTicket = txtOrdenTicket,
				FechaTicket = txtFechaTicket,
				StatusTicket = txtStatusTicket,
				FirstLastName = txtNombreApellido,
				DetalleTicket = btnDetalle,
				Semaforo = imgSemaforo
			};

			return view;

		}
		public override int ItemCount {
			get {
				return mTickets.Count;
			}
		}
		#endregion
	}
}

