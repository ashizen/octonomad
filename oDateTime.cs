using System;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class oDateTime : IEquatable<oDateTime>
{
    public DateTime dateTime { get; set; }
    OctonaryCalendar ocal;

    public oDateTime(long oTicks)
    {
        ocal = new OctonaryCalendar();

        dateTime = new DateTime(oTicks);
    }

    public override String ToString()
    {
        return String.Format("{0}, {1} {2} {3}.", ocal.GetODayOfWeek(dateTime).ToString(),
            ocal.GetMonthOfYear(dateTime), ocal.GetDayOfMonth(dateTime), ocal.GetYear(dateTime));
    }

    public bool Equals(oDateTime eq)
    {
        return DateTime.Equals(dateTime.ToString(), eq.ToString());
    }
}