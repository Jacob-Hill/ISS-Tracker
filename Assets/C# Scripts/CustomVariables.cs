using System;

public struct Position
{
    public Position(double lat, double lon)
    {
        Lat = lat;
        Long = lon;
    }

    public Position(string lat, string lon)
    {
        Lat = Convert.ToDouble(lat);
        Long = Convert.ToDouble(lon);
    }

    public double Lat { get; }
    public double Long { get; }

    public override string ToString() => $"({Lat}, {Long})";
}

public struct Clock
{
    public Clock(int year, int month, int day, int hour, int minute, float second)
    {
        Year = year;
        Month = month;
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public Clock(string year, string month, string day, string hour, string minute, string second)
    {
        Year = Convert.ToInt32(year);
        Month = Convert.ToInt32(month);
        Day = Convert.ToInt32(day);
        Hour = Convert.ToInt32(hour);
        Minute = Convert.ToInt32(minute);
        Second = (float)Convert.ToDouble(second);
    }

    public int Year { get; }
    public int Month { get; }
    public int Day { get; }
    public int Hour { get; }
    public int Minute { get; }
    public float Second { get; }

    public override string ToString() => $"({Day}/{Month}/{Year},{Hour}:{Minute}:{Second})";

}