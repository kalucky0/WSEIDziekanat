using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services;

public class FinancesDataService: IGridDataService<Payment>
{
    private List<Payment> _payments;

    private static IEnumerable<Payment> AllPayments() =>
        App.Database.Payments.OrderBy(a => a.Due);
    
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