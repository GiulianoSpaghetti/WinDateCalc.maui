namespace WinDateCalc.maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
#if ANDROID
		scMain.Title = App.GetResource(Resource.String.application);
		scInfo.Title = App.GetResource(Resource.String.informations);
#else
		scMain.Title = "Application";
		scInfo.Title = "Informations";
#endif
	}
}
