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
        lblnome.Text=App.GetResource(WinDateCalc.maui.Resource.String.lblname);
        lbldescrizione.Text=App.GetResource(WinDateCalc.maui.Resource.String.lbldescription);
        btnCalendar.Text=App.GetResource(WinDateCalc.maui.Resource.String.btncalendar);
        btnCalendar.IsVisible = true;
        btnCalendar.IsEnabled = false;
#else
        Title = "Application";
        ldate.Text="Insert the date";
        bok.Text="Calculate";
        lblnome.Text = "Name: ";
        lbldescrizione.Text = "Description: ";
        btnCalendar.IsVisible = false;
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
        btnCalendar.IsEnabled = false;
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
        btnCalendar.IsEnabled = true;
    }

    private async void info_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoPage());
    }

    private void OnCalendar_Click(object sender, EventArgs e)
    {
#if ANDROID 
            risultato.Text="";
            btnCalendar.IsEnabled = false;
            if (enome.Text=="") {
                risultato.Text=App.GetResource(WinDateCalc.maui.Resource.String.invalid_title);
                return;
            }
            if (edescrizione.Text=="") {
                risultato.Text=App.GetResource(WinDateCalc.maui.Resource.String.invalid_description);
                return;
             }
            if (!WinDateCalc.maui.Platforms.Android.CalendarHelperService.Set(enome.Text, edescrizione.Text, data.Date))
                risultato.Text=App.GetResource(WinDateCalc.maui.Resource.String.calendar_error);
            else
                risultato.Text=App.GetResource(WinDateCalc.maui.Resource.String.inserted_into_calendar);
#endif
    }

}

