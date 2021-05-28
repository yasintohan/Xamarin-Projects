package crc64444a75afed94a721;


public class DebugGridViewDroid
	extends android.view.View
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"n_onDraw:(Landroid/graphics/Canvas;)V:GetOnDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.Forms.DebugRainbows.DebugGridViewDroid, Xamarin.Forms.DebugRainbows", DebugGridViewDroid.class, __md_methods);
	}


	public DebugGridViewDroid (android.content.Context p0)
	{
		super (p0);
		if (getClass () == DebugGridViewDroid.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.DebugRainbows.DebugGridViewDroid, Xamarin.Forms.DebugRainbows", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public DebugGridViewDroid (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == DebugGridViewDroid.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.DebugRainbows.DebugGridViewDroid, Xamarin.Forms.DebugRainbows", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public DebugGridViewDroid (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == DebugGridViewDroid.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.DebugRainbows.DebugGridViewDroid, Xamarin.Forms.DebugRainbows", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public DebugGridViewDroid (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == DebugGridViewDroid.class)
			mono.android.TypeManager.Activate ("Xamarin.Forms.DebugRainbows.DebugGridViewDroid, Xamarin.Forms.DebugRainbows", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);


	public void onDraw (android.graphics.Canvas p0)
	{
		n_onDraw (p0);
	}

	private native void n_onDraw (android.graphics.Canvas p0);

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
