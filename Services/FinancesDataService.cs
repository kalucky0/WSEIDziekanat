using System.Collections.Generic;
using System.Threading.Tasks;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services;

public class FinancesDataService: IGridDataService<Payment>
{
    private List<Payment> _payments;

    private static IEnumerable<Payment> AllPayments()
    {
        return new List<Payment>
        {
            new(0,
                "informatyka stosowana",
                "2021-10-11",
                "Uregulowane",
                "0 PLN",
                "740 PLN",
                "2021-09-15",
                "odsetki: 0 PLN\nbonifkata: 0 PLN\numorzenie: 0 PLN"
            ),
            new(0,
                "informatyka stosowana",
                "2021-11-10",
                "Uregulowane",
                "0 PLN",
                "740 PLN",
                "2021-10-27",
                "odsetki: 0 PLN\nbonifkata: 0 PLN\numorzenie: 0 PLN"
            ),
        };
    }
    
    public async Task<IEnumerable<Payment>> GetContentGridDataAsync()
    {
        if (_payments == null)
            _payments = new List<Payment>(AllPayments());

        await Task.CompletedTask;
        return _payments;
    }

    public async Task<IEnumerable<Payment>> GetGridDataAsync()
    {
        if (_payments == null)
            _payments = new List<Payment>(AllPayments());

        await Task.CompletedTask;
        return _payments;
    }
}