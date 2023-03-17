using Android.Content;
using Android.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.CalendarContract;
namespace WinDateCalc.maui.Platforms.Android
{
    public class CalendarHelperService
    {
        public static bool Set(String nome, String descrizione, DateTime d)
        {
            return MainActivity.Instance.calendarHelper(nome, descrizione, d);
        }
    }
}
