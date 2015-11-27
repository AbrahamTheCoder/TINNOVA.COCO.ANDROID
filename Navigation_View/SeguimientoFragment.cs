
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
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.Widget;
using Navigation_View.cocoservices.tinnova.mx;

namespace Navigation_View
{
	public class SeguimientoFragment : Android.Support.V4.App.Fragment
	{

		private List<Ticket> mTickets;
		private List<TicketDetail> mTicketsDetails;
		private RecyclerView mRecyclerView;
		private RecyclerView.LayoutManager mLayoutManager;
		private RecyclerView.Adapter mAdapter;
		public FrameLayout mFrameLayoutContainer;
		private SupportFragment mCurrentFragment = new SupportFragment();

		public SeguimientoFragment()
		{	
			this.RetainInstance = true;
		}

		public static Android.Support.V4.App.Fragment newInstance(Context context)
		{
			SeguimientoFragment seguimiento = new SeguimientoFragment ();
			return seguimiento;
		}

		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView (inflater, container, savedInstanceState);

			var view = (ViewGroup)inflater.Inflate (Resource.Layout.layout_seguimiento, null);
			string string_key = "41f579fc-1445-4065-ab10-c06d50e724d3";

			mFrameLayoutContainer = view.FindViewById<FrameLayout> (Resource.Id.RelativeSeguimientoDetail);

			var trans = Activity.SupportFragmentManager.BeginTransaction ();

			mCurrentFragment = this;
			trans.Commit ();

			mRecyclerView = view.FindViewById<RecyclerView> (Resource.Id.RecyclerViewerSeguimiento);

			cocoservices.tinnova.mx.COCOService cliente = new Navigation_View.cocoservices.tinnova.mx.COCOService ();
			Navigation_View.cocoservices.tinnova.mx.TicketDTO[] TicketDTOList = new Navigation_View.cocoservices.tinnova.mx.TicketDTO[50];
			mTickets = new List<Ticket> ();
			mTicketsDetails = new List<TicketDetail> ();

			TicketDTOList = cliente.GetTicketsByUser ("cnkmor@gmail.com", string_key);

			foreach (TicketDTO value in TicketDTOList) {
				mTickets.Add (new Ticket {
					Nombre = value.Client.FirstName + value.Client.LastName,
					Ciudad = value.Client.AddressCity,
					CodigoPostal = value.Client.PostalCode,
					Email = value.Client.Email,
					Estado = value.Client.AddressState,
					Fecha = value.TicketDate,
					Nota = value.Notes,
					Telefono = value.Client.Phone,
					Tipo = value.Type.ObjId.ToString (),
					TicketID = value.Id.ToString (),
					Estatus = value.Status.Name
				});
				foreach (TicketDetailDTO valueDetail in value.TicketDetail) {
					mTicketsDetails.Add (new TicketDetail {
						AgenteID = valueDetail.Agent.UserId,
						Asunto = valueDetail.Subject,
						Fecha = valueDetail.DetailDate,
						Mensaje = valueDetail.Message,
						StatusID = valueDetail.Status.Id,
						Status = valueDetail.Status.Name,
						TicketID = valueDetail.TIC_ID
					});
				}
			}

			mLayoutManager = new LinearLayoutManager (view.Context);
			mRecyclerView.SetLayoutManager (mLayoutManager);
			mAdapter = new Seguimiento_Adapter (mTickets, mTicketsDetails, mRecyclerView, view.Context);
			mRecyclerView.SetAdapter (mAdapter);

			return view;

		}
	}
}

