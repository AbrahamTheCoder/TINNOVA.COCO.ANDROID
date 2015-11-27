using System;
using Android.Support.V7.Widget;
using Android.Content;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Dalvik.SystemInterop;
using Android.App;
using Android.Graphics.Drawables;

namespace Navigation_View
{
	public class SeguimientoDetail_Adapter : BaseAdapter<TicketDetail>
	{

		private Activity mContext;
		private List<TicketDetail> mTicketDetails;

		public SeguimientoDetail_Adapter(List<TicketDetail> lista, Activity context)
		{
			mTicketDetails = lista;
			//mRecyclerView = recycler;
			mContext = context;
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return position;
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			var item = mTicketDetails [position];
			View view = convertView;
			if (view == null)
				view = mContext.LayoutInflater.Inflate (Resource.Layout.layout_row_detalleTicket, null);

			if (item.Asunto == "Mensaje Consumidor") {
				view.FindViewById<ImageView> (Resource.Id.img_portadaUser).SetImageResource (Resource.Drawable.chatYo);
			} else {
				view.FindViewById<ImageView> (Resource.Id.img_portadaUser).SetImageResource (Resource.Drawable.chat911);
			}

			view.FindViewById<TextView> (Resource.Id.txtFechaDetalleTicket).Text = item.Fecha.ToString ();
			view.FindViewById<TextView> (Resource.Id.txtMensajeTicketDetail).Text = item.Mensaje;


			return view;
		}

		public override int Count {
			get {
				return mTicketDetails.Count;
			}
		}

		#endregion

		#region implemented abstract members of BaseAdapter

		public override TicketDetail this [int index] {
			get {
				return mTicketDetails [index];
			}
		}

		#endregion
	}
}

