namespace WinDateCalc.maui;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
        Title = App.GetResource(WinDateCalc.maui.Resource.String.informations);
	}
    private async void OnSito_Click(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync(new Uri("https://github.com/numerunix/WinDateCalc.maui"));
    }
}