using System;
using System.Collections.Generic;

public class Week : List<Day>
{
    public WeekType weekType;
    bool hebdad;

    public Week(WeekType wt)
    {
        if (wt == WeekType.hebdad) { for (int i = 0; i < 7; i++) { this.Add(new Day()); } }
        else { for (int i = 0; i < 8; i++) { this.Add(new Day()); } }
    }
    public enum WeekType
    {
        hebdad, ogdad
    }
}
