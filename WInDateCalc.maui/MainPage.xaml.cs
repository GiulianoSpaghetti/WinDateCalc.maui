namespace WInDateCalc.maui;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        while (true)
            try
            {
                data.Date = DateTime.Parse(Preferences.Get("Data", DateTime.Now.ToString()));
                break;
            }
            catch (FormatException e)
            {
                Preferences.Clear();
            }
    }

    private void calcola_Click(object sender, EventArgs e)
    {
        DateTime d = DateTime.Now;
        TimeSpan differenza = data.Date.Date - d;
        risultato.Text = $"Mancano {differenza.Days} giorni.";
        Preferences.Set("Data", data.Date.Date.ToString());
    }

    private async void info_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoPage());
    }
}

