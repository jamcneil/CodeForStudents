package md50a6d2e25c3099f84ff1bdebbad4f41de;


public class MyTimer
	extends android.os.CountDownTimer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFinish:()V:GetOnFinishHandler\n" +
			"n_onTick:(J)V:GetOnTick_JHandler\n" +
			"";
		mono.android.Runtime.register ("TestTimer.MyTimer, TestTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyTimer.class, __md_methods);
	}


	public MyTimer (long p0, long p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == MyTimer.class)
			mono.android.TypeManager.Activate ("TestTimer.MyTimer, TestTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Int64, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int64, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public void onFinish ()
	{
		n_onFinish ();
	}

	private native void n_onFinish ();


	public void onTick (long p0)
	{
		n_onTick (p0);
	}

	private native void n_onTick (long p0);

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
