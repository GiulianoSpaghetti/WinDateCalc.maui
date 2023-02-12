namespace WInDateCalc.maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		scMain.Title = App.GetResource(WinDateCalc.maui.Resource.String.application);
		scInfo.Title = App.GetResource(WinDateCalc.maui.Resource.String.informations);
	}
}
