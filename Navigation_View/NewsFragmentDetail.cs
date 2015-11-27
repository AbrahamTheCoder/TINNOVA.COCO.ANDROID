
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
using System.Runtime.InteropServices;
using Android.Graphics.Drawables;

namespace Navigation_View
{
	public class NewsFragmentDetail : Android.Support.V4.App.Fragment
	{

		//private adapter_listview mAdapter;
		public int ShownPlayId { get { return Arguments.GetInt("current_play_id", 0); } }

		public string Titulos { get { return Arguments.GetString ("txtTituloDetalle", ""); } }
		public string Subtitulos { get { return Arguments.GetString ("txtSubtituloDetalle", string.Empty); } }
		public string Fechas { get { return Arguments.GetString ("txtFechaContenidoDetalle", string.Empty); } }
		public string Portadas { get { return Arguments.GetString ("img_portadaDetalle", string.Empty); } }
		public string Contenidos { get { return Arguments.GetString ("txtContenidoDetalle", string.Empty); } }


		public static Android.Support.V4.App.Fragment newInstance(string titulo, string subtitulo, string fecha, string portada, string contenido)
		{
			NewsFragmentDetail NewsFragments = new NewsFragmentDetail{ Arguments = new Bundle () };
			NewsFragments.Arguments.PutString ("txtTituloDetalle", titulo);
			NewsFragments.Arguments.PutString ("txtSubtituloDetalle", subtitulo);
			NewsFragments.Arguments.PutString ("txtFechaContenidoDetalle", fecha);
			NewsFragments.Arguments.PutString ("img_portadaDetalle", portada);
			NewsFragments.Arguments.PutString ("txtContenidoDetalle", contenido);
			return NewsFragments;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{

			if (container == null)
			{
				// Currently in a layout without a container, so no reason to create our view.
				return null;
			}

			var view = (ViewGroup)inflater.Inflate (Resource.Layout.layout_item, container, false);

			view.FindViewById<TextView> (Resource.Id.txtTituloDetalle).Text = Titulos;
			view.FindViewById<TextView> (Resource.Id.txtSubtituloDetalle).Text = Subtitulos;
			view.FindViewById<TextView> (Resource.Id.txtFechaContenidoDetalle).Text = Fechas;
			//view.FindViewById<ImageView> (Resource.Id.img_portadaDetalle).set
			Koush.UrlImageViewHelper.SetUrlDrawable (view.FindViewById<ImageView> (Resource.Id.img_portadaDetalle),Portadas);
			view.FindViewById<TextView> (Resource.Id.txtContenidoDetalle).Text = Contenidos;

			//view.FindViewById<TextView> (Resource.Id.txtTituloDetalle).Text = 

			return view;
		}
	}
}

