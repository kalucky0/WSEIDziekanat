namespace WSEIDziekanat.Models;

public class Announcement
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Priority { get; set; }
    public string Date { get; set; }
    public bool IsRead { get; set; }

    public Announcement(int id, string title, string priority, string date, bool isRead)
    {
        Id = id;
        Title = title;
        Priority = priority;
        Date = date;
        IsRead = isRead;
    }
}