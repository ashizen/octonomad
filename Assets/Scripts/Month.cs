using System;

public class Month
{
    public int days;
    public MonthType monthType;
    public Month(MonthType mt, bool odd = false)
    {
        if (mt == MonthType.hMonth || odd = true) { days = 31; }
        else if (mt == MonthType.hMonth || odd = false) { days = 30; }
    }

    public enum MonthType
    { hMonth, oMonth}
}
