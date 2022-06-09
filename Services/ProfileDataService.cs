using WSEIDziekanat.Contracts.Services;
using WSEIDziekanat.Models;

namespace WSEIDziekanat.Services;

public class ProfileDataService : IProfileDataService
{
    private Student _student;

    public Student GetData()
    {
        return new Student(0,
            "Jan",
            "Andrzej",
            "Kowalski",
            "Informatyka stosowana",
            "13682",
            "321456987654",
            "2000-01-01",
            "Warszawa",
            "—",
            "Mężczyzna",
            "Kawaler",
            "Polska",
            "polskie",
            "ABC 12345",
            "Prezydent miasta Warszawy",
            "—",
            "—",
            "Grażyna",
            "Nowak",
            "Janusz",
            "Kowalski",
            "3124789871234",
            "PKO S.A.",
            "Ulicowa 1",
            "01-234",
            "Warszawa",
            "Warszawa",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            0,
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
        );
    }
}