using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Kadrovska_sluzba.Helpers
{
    public class RegionalSettings
    {
        public static void SetRegionalSettings()
        {
            Application.DoEvents();

            //REGIONAL SETTINGS
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("sl-SI"));
            CultureInfo ci = new CultureInfo("en-US");
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencySymbol = "KM";
            nfi.CurrencyPositivePattern = 3;
            nfi.CurrencyNegativePattern = 8;
            nfi.NumberDecimalSeparator = ",";
            nfi.NumberGroupSeparator = ".";
            ci.NumberFormat = nfi;
            ci.DateTimeFormat.PMDesignator = String.Empty;
            ci.DateTimeFormat.AMDesignator = String.Empty;
            ci.DateTimeFormat.ShortTimePattern = "HH:mm:ss";
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yy";
            ci.DateTimeFormat.LongDatePattern = "dd MMMM, yyyy";
            ci.Calendar.TwoDigitYearMax = 2050;
            Thread.CurrentThread.CurrentCulture = ci;
        }
    }
}
