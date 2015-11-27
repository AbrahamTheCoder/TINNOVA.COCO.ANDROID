using System;
using Android.Widget;
using System.Collections.Generic;
using Android.App;
using System.Linq;
using Android.Graphics;
using Android.Graphics.Drawables;
using Java.IO;
using Android.Media;
using System.IO;
using Java.Net;
using System.Net;
using System.Collections;
using Java.Util;
using Android.Support.V7.Widget;
using Android.Content;
using Android.Views;
using Java.Security;
using Java.Lang;
using Android.Text;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V4.View;
using Java.Util.Zip;

namespace Navigation_View
{
	public class adapter_listview : RecyclerView.Adapter
	{


		private List<Publicaciones> mPublicaciones;
		private RecyclerView mRecyclerView;
		private Context mContext;

		public adapter_listview(List<Publicaciones> publicaciones, RecyclerView recycler, Context context)
		{
			mPublicaciones = publicaciones;
			mRecyclerView = recycler;
			mContext = context;
		}

		public class NewsAdapterWrapper : RecyclerView.ViewHolder
		{
			public View mView { get; set;}
			public TextView Titulo { get; set;}
			public TextView Subtitulo { get; set;}
			public TextView Fecha { get; set;}
			public TextView Contenido { get; set;}
			public ImageView Imagen { get; set;}
			public Button Detalle { get; set;}

			public NewsAdapterWrapper (View view) : base(view)
			{
				mView = view;
			}

		}

		public override int GetItemViewType(int position)
		{

			return Resource.Layout.layout_group;
		}


		#region implemented abstract members of Adapter

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			NewsAdapterWrapper Myholder = holder as NewsAdapterWrapper;
			Myholder.Titulo.Text = mPublicaciones [position].Titulo;
			Myholder.Subtitulo.Text = mPublicaciones [position].Subtitulo;
			Myholder.Fecha.Text = mPublicaciones [position].FechaPublicacion.ToString ();
			Koush.UrlImageViewHelper.SetUrlDrawable (Myholder.Imagen, mPublicaciones [position].Imagen.ToString ());
			Myholder.Detalle.Visibility = ViewStates.Gone;
			Myholder.Imagen.Click += (object sender, EventArgs e) => 
			{
				Intent IntentNews = new Intent(this.mContext,typeof(NewsDetailActivity));
				IntentNews.PutExtra ("TituloDetalle", mPublicaciones [position].Titulo);
				IntentNews.PutExtra ("SubtituloDetalle", mPublicaciones [position].Subtitulo);
				IntentNews.PutExtra ("FechaDetalle", mPublicaciones [position].FechaPublicacion.ToString ());
				IntentNews.PutExtra ("ContenidoDetalle", mPublicaciones [position].Contenido.Trim ());
				IntentNews.PutExtra ("ImagenDetalle", mPublicaciones [position].Imagen.ToString ());

				this.mContext.StartActivity (IntentNews);
			};
//			Myholder.Detalle.Click += (object sender, EventArgs e) => 
//			{
//				Intent IntentNews = new Intent(this.mContext,typeof(NewsDetailActivity));
//				IntentNews.PutExtra ("TituloDetalle", mPublicaciones [position].Titulo);
//				IntentNews.PutExtra ("SubtituloDetalle", mPublicaciones [position].Subtitulo);
//				IntentNews.PutExtra ("FechaDetalle", mPublicaciones [position].FechaPublicacion.ToString ());
//				IntentNews.PutExtra ("ContenidoDetalle", mPublicaciones [position].Contenido.Trim ());
//				IntentNews.PutExtra ("ImagenDetalle", mPublicaciones [position].Imagen.ToString ());
//				this.mContext.StartActivity (IntentNews);
//			};
		}
			
		public override RecyclerView.ViewHolder OnCreateViewHolder (Android.Views.ViewGroup parent, int viewType)
		{
			View row = LayoutInflater.From (mContext).Inflate (Resource.Layout.layout_group,parent,false);

			TextView txtTitulo = row.FindViewById<TextView> (Resource.Id.txtTitulo);
			TextView txtSubtitulo = row.FindViewById<TextView> (Resource.Id.txtSubtitulo);
			TextView txtFecha = row.FindViewById<TextView> (Resource.Id.txtFechaContenido);
			ImageView image = row.FindViewById<ImageView> (Resource.Id.img_portada);
			Button btnDetalle = row.FindViewById<Button> (Resource.Id.btnDetalle);

			NewsAdapterWrapper view = new NewsAdapterWrapper (row) {
				Titulo = txtTitulo,
				Subtitulo = txtSubtitulo,
				Fecha = txtFecha,
				Imagen = image,
				Detalle = btnDetalle
			};

			return view;

		}

		public override int ItemCount {
			get {
				return mPublicaciones.Count;
			}
		}

		#endregion




	}
}

