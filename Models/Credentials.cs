namespace WSEIDziekanat.Models;

public class Credentials
{
    public int Uid { get; }
    public string Login { get; }
    public string Password { get; }

    public Credentials(int uid, string login, string password)
    {
        Uid = uid;
        Login = login;
        Password = password;
    }
}