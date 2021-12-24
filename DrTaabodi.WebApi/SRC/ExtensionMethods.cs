using System;
using System.Globalization;

namespace DrTaabodi.WebApi
{
    public static class ExtensionMethods
    {
        static PersianCalendar _persianCalendar = null;
        static PersianCalendar GetPersianCalendar
        {
            get
            {
                if (_persianCalendar == null)
                    _persianCalendar = new PersianCalendar();
                return _persianCalendar;
            }
        }


        public static string ToPersianCalender(this DateTime dateTime, bool withTime = false)
        {
            try
            {
                return $"{_persianCalendar.GetYear(dateTime)}/{_persianCalendar.GetMonth(dateTime)}/{_persianCalendar.GetDayOfMonth(dateTime)}" +
               (withTime ? dateTime.ToShortTimeString() : "");
            }
            catch
            {

                return "";
            }
        }
    }
}
