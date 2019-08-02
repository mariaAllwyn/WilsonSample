package md507626d83de28cfea1bad4922c2e71227;


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
		mono.android.Runtime.register ("SampleCode.ViewHolderVA, SampleCode", ViewHolderVA.class, __md_methods);
	}


	public ViewHolderVA ()
	{
		super ();
		if (getClass () == ViewHolderVA.class)
			mono.android.TypeManager.Activate ("SampleCode.ViewHolderVA, SampleCode", "", this, new java.lang.Object[] {  });
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
