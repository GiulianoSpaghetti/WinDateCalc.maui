namespace WInDateCalc.maui;
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
        ldate.Text = GetResource(WinDateCalc.maui.Resource.String.insert_the_date);
        bok.Text=GetResource(WinDateCalc.maui.Resource.String.calculate);
        binfo.Text=GetResource(WinDateCalc.maui.Resource.String.informations);
#elif NET7_0_OR_GREATER
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
            risultato.Text = GetResource(WinDateCalc.maui.Resource.String.invalid_lvalue);
#elif NET7_0_OR_GREATER
#endif
            return;
        }
#if ANDROID
    risultato.Text = $"{GetResource(WinDateCalc.maui.Resource.String.there_are)} {Math.Ceiling(differenza.TotalDays)} {GetResource(WinDateCalc.maui.Resource.String.days_left)}.";
#elif NET7_0_OR_GREATER
#endif
        Preferences.Set("Data", data.Date.ToString());
    }

    private async void info_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoPage());
    }

#if ANDROID
    private System.String GetResource(int id)
    {
        return Android.App.Application.Context.Resources.GetString(id);

    }
#elif NET7_0_OR_GREATER
    private System.String GetResource(string id)
    {
        return Resources[id].ToString();
    }
#endif
}

