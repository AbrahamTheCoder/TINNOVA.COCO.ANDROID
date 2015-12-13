package md5f9c5657ee0cdb65189d6cc51fb6de8b7;


public class IniciarSesionActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Navigation_View.IniciarSesionActivity, Navigation_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", IniciarSesionActivity.class, __md_methods);
	}


	public IniciarSesionActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == IniciarSesionActivity.class)
			mono.android.TypeManager.Activate ("Navigation_View.IniciarSesionActivity, Navigation_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
