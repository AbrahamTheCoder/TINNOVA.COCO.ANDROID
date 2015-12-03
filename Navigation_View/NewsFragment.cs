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
using Android.Hardware.Camera2;
using Android.Media.Midi;
using Android.Support.V7.Widget;
using SupportFragment = Android.Support.V4.App.Fragment;
using Navigation_View.services_911consumidor_com;

namespace Navigation_View
{
	public class NewsFragment : Android.Support.V4.App.Fragment
	{

		private List<Publicaciones> mPublicaciones;
		private RecyclerView mRecyclerView;
		private RecyclerView.LayoutManager mLayoutManager;
		private RecyclerView.Adapter mAdapter;
		public FrameLayout mFrameLayoutContainer;
		//private NewsFragmentDetail NewsDetail;
		private SupportFragment mCurrentFragment = new SupportFragment();

		public NewsFragment()
		{	
			this.RetainInstance = true;
		}

		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Bundle savedInstanceState)
		{
			var ignored = base.OnCreateView (inflater,container,savedInstanceState);
			var view = (ViewGroup)inflater.Inflate (Resource.Layout.layout_news, null);
			var viewGroup = (ViewGroup)inflater.Inflate (Resource.Layout.layout_group, null);
			string string_key = "41f579fc-1445-4065-ab10-c06d50e724d3";
			//NewsDetail = new NewsFragmentDetail ();

			//var mFragmentItemContainer = viewGroup.FindViewById<FrameLayout> (Resource.Id.fragment4Container);

			Button button = viewGroup.FindViewById<Button> (Resource.Id.btnDetalle);

			mFrameLayoutContainer = view.FindViewById<FrameLayout> (Resource.Id.RelativeLay);

			var trans = Activity.SupportFragmentManager.BeginTransaction ();
			//trans.Add (mFragmentItemContainer.Id, new NewsFragmentDetail (), "Detail");
			//trans.Add (Resource.Id.layout_content, NewsDetail);
			//trans.Hide (NewsDetail);
			mCurrentFragment = this;
			trans.Commit ();


			mRecyclerView = view.FindViewById<RecyclerView> (Resource.Id.RecyclerViewer);
			//Pruebas

			//cocoservices.tinnova.mx.COCOService cliente = new Navigation_View.cocoservices.tinnova.mx.COCOService ();
			//Navigation_View.cocoservices.tinnova.mx.PublicationDTO[] mPublicacion = new Navigation_View.cocoservices.tinnova.mx.PublicationDTO[5];

			//Produccion

			services_911consumidor_com.COCOService cliente = new Navigation_View.services_911consumidor_com.COCOService();
			Navigation_View.services_911consumidor_com.PublicationDTO[] mPublicacion = new Navigation_View.services_911consumidor_com.PublicationDTO[5];

			mPublicacion = cliente.GetActivePublications (string_key);
			mPublicaciones = new List<Publicaciones> ();

			foreach (PublicationDTO value in mPublicacion) {
				mPublicaciones.Add (new Publicaciones {
					Titulo = value.Tittle,
					FechaPublicacion = value.PublicationDate,
					Subtitulo = value.SubTittle,
					Imagen = value.ImageUrl,
					IdPublicacion = value.Id,
					Contenido = value.Content
				});
			}

			mLayoutManager = new LinearLayoutManager (view.Context);
			mRecyclerView.SetLayoutManager (mLayoutManager);
			mAdapter = new adapter_listview (mPublicaciones, mRecyclerView, view.Context);
			mRecyclerView.SetAdapter (mAdapter);


			return view;
			// Create your fragment here
		}

		public static Android.Support.V4.App.Fragment newInstance(Context context)
		{
			NewsFragment news = new NewsFragment ();
			return news;
		}
	}
}

