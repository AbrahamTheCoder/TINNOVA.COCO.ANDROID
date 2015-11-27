package md5f9c5657ee0cdb65189d6cc51fb6de8b7;


public class adapter_listview_NewsAdapterWrapper
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Navigation_View.adapter_listview+NewsAdapterWrapper, Navigation_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", adapter_listview_NewsAdapterWrapper.class, __md_methods);
	}


	public adapter_listview_NewsAdapterWrapper (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == adapter_listview_NewsAdapterWrapper.class)
			mono.android.TypeManager.Activate ("Navigation_View.adapter_listview+NewsAdapterWrapper, Navigation_View, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

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
