using System.Linq;
using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services;

public class ProfileDataService : IDataService<Student>
{
    public Student GetData() =>
        App.Database.Students.First();
}