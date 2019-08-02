package md5dcdf68243b690141d25ac565d79861a6;


public class ViewHolderVA
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SampleCode.ViewHolderVA, SampleCode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ViewHolderVA.class, __md_methods);
	}


	public ViewHolderVA () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ViewHolderVA.class)
			mono.android.TypeManager.Activate ("SampleCode.ViewHolderVA, SampleCode, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
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
