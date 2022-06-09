namespace WSEIDziekanat.Models;

public class Payment
{
    public int Uid { get; }
    public string Name { get; }
    public string Due { get; }
    public string State { get; }
    public string AmountNow { get; }
    public string Amount { get; }
    public string PaymentDate { get; }
    public string AdditionalInfo { get; }

    public Payment(int uid, string name, string due, string state, string amountNow, string amount, string paymentDate,
        string additionalInfo)
    {
        Uid = uid;
        Name = name;
        Due = due;
        State = state;
        AmountNow = amountNow;
        Amount = amount;
        PaymentDate = paymentDate;
        AdditionalInfo = additionalInfo;
    }
}