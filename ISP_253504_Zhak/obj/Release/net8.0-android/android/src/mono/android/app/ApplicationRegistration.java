package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("Microsoft.Maui.MauiApplication, Microsoft.Maui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc6488302ad6e9e4df1a.MauiApplication.class, crc6488302ad6e9e4df1a.MauiApplication.__md_methods);
		mono.android.Runtime.register ("ISP_253504_Zhak.MainApplication, ISP_253504_Zhak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc6458177951e34b8d7f.MainApplication.class, crc6458177951e34b8d7f.MainApplication.__md_methods);
		
	}
}
