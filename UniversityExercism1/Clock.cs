using System;

public class Clock : IEquatable<Clock>
{
    private const int MinutesPerDay = 24 * 60;
    private readonly int minutes;

    public Clock(int hours, int minutes)
    {
        this.minutes = Normalize((long)hours * 60 + minutes);
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(0, Normalize((long)minutes + minutesToAdd));
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(0, Normalize((long)minutes - minutesToSubtract));
    }

    public override string ToString() => $"{minutes / 60:D2}:{minutes % 60:D2}";

    public bool Equals(Clock? other) => other is not null && minutes == other.minutes;

    public override bool Equals(object? obj) => obj is Clock other && Equals(other);

    public override int GetHashCode() => minutes.GetHashCode();

    private static int Normalize(long minutes) =>
        (int)((minutes % MinutesPerDay + MinutesPerDay) % MinutesPerDay);
}
