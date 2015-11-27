﻿
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
using Android.Text.Method;
using Android.Support.V7.App;
using Android.Support.V4.Widget;

namespace Navigation_View
{
	[Activity (Label = "Boletín", Theme="@style/MyTheme")]			
	public class NewsDetailActivity : AppCompatActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			Android.Support.V7.Widget.Toolbar _supporttoolbar;
			SetContentView (Resource.Layout.layout_item);

			_supporttoolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.ToolBarBoletin);
			_supporttoolbar.SetTitle(Resource.String.boletin);
			SetSupportActionBar(_supporttoolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(false);


			TextView txtTituloDetalle = FindViewById<TextView> (Resource.Id.txtTituloDetalle);
			TextView txtSubtituloDetalle = FindViewById<TextView> (Resource.Id.txtSubtituloDetalle);
			TextView txtFechaDetalle = FindViewById<TextView> (Resource.Id.txtFechaContenidoDetalle);
			TextView txtContenidoDetalle = (TextView)FindViewById<TextView> (Resource.Id.txtContenidoDetalle);
			ImageView ImagenDetalle = FindViewById<ImageView> (Resource.Id.img_portadaDetalle);

			txtContenidoDetalle.MovementMethod = new ScrollingMovementMethod ();

			txtTituloDetalle.Text = Intent.GetStringExtra ("TituloDetalle");
			txtSubtituloDetalle.Text = Intent.GetStringExtra ("SubtituloDetalle");
			txtFechaDetalle.Text = Intent.GetStringExtra ("FechaDetalle");
			txtContenidoDetalle.Text = Intent.GetStringExtra ("ContenidoDetalle");
			Koush.UrlImageViewHelper.SetUrlDrawable (ImagenDetalle, Intent.GetStringExtra ("ImagenDetalle"));


		}
	}
}
