namespace WinDateCalc.maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		scMain.Title = App.GetResource(Resource.String.application);
		scInfo.Title = App.GetResource(Resource.String.informations);
	}
}
