namespace WSEIDziekanat.Models;

public class Payment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Due { get; set; }
    public string State { get; set; }
    public string AmountNow { get; set; }
    public string Amount { get; set; }
    public string PaymentDate { get; set; }
    public string AdditionalInfo { get; set; }

    public Payment(int id, string name, string due, string state, string amountNow, string amount, string paymentDate,
        string additionalInfo)
    {
        Id = id;
        Name = name;
        Due = due;
        State = state;
        AmountNow = amountNow;
        Amount = amount;
        PaymentDate = paymentDate;
        AdditionalInfo = additionalInfo;
    }
}