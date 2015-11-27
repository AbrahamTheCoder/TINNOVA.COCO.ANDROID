using System;
using Android.Media;

namespace Navigation_View
{
	public class Publicaciones
	{


		int intIdPublicacion;
		string strTitulo;
		string strSubtitulo;
		string strContenido;
		DateTime dteFechaPublicacion;
		String imgImagen;

		public int IdPublicacion
		{
			get{ return intIdPublicacion;}
			set{ intIdPublicacion = value;}
		}

		public string Titulo
		{
			get{ return strTitulo;}
			set{ strTitulo = value;}
		}

		public string Subtitulo
		{
			get{ return strSubtitulo;}
			set{ strSubtitulo = value;}
		}

		public string Contenido
		{
			get{ return strContenido;}
			set{ strContenido = value;}
		}

		public DateTime FechaPublicacion
		{
			get{ return dteFechaPublicacion;}
			set{ dteFechaPublicacion = value;}
		}

		public String Imagen
		{
			get{ return imgImagen;}
			set{ imgImagen = value;}
		}


		public void Init (int IdPublicacion,
							  String Titulo,
							  String Subtitulo,
							  String Contenido,
							  DateTime FechaPublicacion,
							  String Imagen)
		{

			this.intIdPublicacion = IdPublicacion;
			this.strTitulo = Titulo;
			this.strSubtitulo = Subtitulo;
			this.strContenido = Contenido;
			this.dteFechaPublicacion = FechaPublicacion;
			this.imgImagen = Imagen;

		}
	}
}

