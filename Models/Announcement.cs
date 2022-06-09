namespace WSEIDziekanat.Models;

public class Announcement
{
    public int Uid { get; }
    public string Title { get; }
    public string Priority { get; }
    public string Date { get; }
    public bool IsRead { get; }
    
    public Announcement(int uid, string title, string priority, string date, bool isRead)
    {
        Uid = uid;
        Title = title;
        Priority = priority;
        Date = date;
        IsRead = isRead;
    }
}