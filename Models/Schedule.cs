namespace WSEIDziekanat.Models;

public class Schedule
{
    public int Id { get; set; }
    public string Day { get; set; }
    public double TimeFrom { get; set; }
    public double TimeTo { get; set; }
    public string Subject { get; set; }
    public string Instructor { get; set; }
    public string Type { get; set; }
    public string Group { get; set; }
    public string Location { get; set; }

    public Schedule(int id, string day, double timeFrom, double timeTo, string subject, string instructor,
        string type, string group, string location)
    {
        Id = id;
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