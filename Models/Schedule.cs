namespace WSEIDziekanat.Models;

public class Schedule
{
    public int Uid { get; }
    public string Day { get; }
    public double TimeFrom { get; }
    public double TimeTo { get; }
    public string Subject { get; }
    public string Instructor { get; }
    public string Type { get; }
    public string Group { get; }
    public string Location { get; }

    public Schedule(int uid, string day, double timeFrom, double timeTo, string subject, string instructor,
        string type, string group, string location)
    {
        Uid = uid;
        Day = day;
        TimeFrom = timeFrom;
        TimeTo = timeTo;
        Subject = subject;
        Instructor = instructor;
        Type = type;
        Group = group;
        Location = location;
    }
}