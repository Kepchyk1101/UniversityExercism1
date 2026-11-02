using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly DateTime firstDay;

    public Meetup(int month, int year)
    {
        firstDay = new DateTime(year, month, 1);
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        int startDay = schedule switch
        {
            Schedule.First => 1,
            Schedule.Second => 8,
            Schedule.Third => 15,
            Schedule.Fourth => 22,
            Schedule.Teenth => 13,
            Schedule.Last => DateTime.DaysInMonth(firstDay.Year, firstDay.Month) - 6,
            _ => throw new ArgumentOutOfRangeException(nameof(schedule))
        };

        DateTime start = firstDay.AddDays(startDay - 1);
        int offset = ((int)dayOfWeek - (int)start.DayOfWeek + 7) % 7;
        return start.AddDays(offset);
    }
}
