namespace WinDateCalc.maui;
public partial class MainPage : ContentPage
{
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
#if ANDROID
        Title=App.GetResource(WinDateCalc.maui.Resource.String.application);
        ldate.Text = App.GetResource(WinDateCalc.maui.Resource.String.insert_the_date);
        bok.Text=App.GetResource(WinDateCalc.maui.Resource.String.calculate);
#else
        Title="Application";
        ldate.Text="Insert the date";
        bok.Text="Calculate";
#endif
    }

    private string GetResource(object insert_the_date)
    {
        throw new NotImplementedException();
    }

    private void calcola_Click(object sender, EventArgs e)
    {
        DateTime d = DateTime.Now;
        TimeSpan differenza = data.Date - d;
        if (differenza.TotalMilliseconds < 0) {
#if ANDROID
            risultato.Text = App.GetResource(WinDateCalc.maui.Resource.String.invalid_lvalue);
#else
            risultato.Text="Invalid lvalue";
#endif
            return;
        }
#if ANDROID
    risultato.Text = $"{App.GetResource(WinDateCalc.maui.Resource.String.there_are)} {Math.Ceiling(differenza.TotalDays)} {App.GetResource(WinDateCalc.maui.Resource.String.days_left)}.";
#else
    risultato.Text= $"There are {Math.Ceiling(differenza.TotalDays)} days left.";
#endif
        Preferences.Set("Data", data.Date.ToString());
    }

    private async void info_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoPage());
    }

}

