namespace WSEIDziekanat.Models;

class Student
{
    public int Uid { get; }
    public string Name { get; }
    public string SecondName { get; }
    public string Surname { get; }
    public string Course { get; }
    public string Index { get; }
    public string Pesel { get; }
    public string Birthdate { get; }
    public string BirtPlace { get; }
    public string Nip { get; }
    public string Sex { get; }
    public string MartialStatus { get; }
    public string Nationality { get; }
    public string Citizenship { get; }
    public string Id { get; }
    public string IdIssuedBy { get; }
    public string Passport { get; }
    public string MilitaryId { get; }
    public string MotherName { get; }
    public string MotherSurname { get; }
    public string FatherName { get; }
    public string FatherSurname { get; }
    public string AccountNumber { get; }
    public string BankName { get; }
    public string Street { get; }
    public string PostCode { get; }
    public string Town { get; }
    public string Post { get; }
    public string MailStreet { get; }
    public string MailPostCode { get; }
    public string MailTown { get; }
    public string MailPost { get; }
    public string PersonalEmail { get; }
    public string Email { get; }
    public string Landline { get; }
    public string Mobile { get; }
    public string Additional { get; }
    public string MaturaId { get; }
    public string MaturaDate { get; }
    public int GraduationHighSchool { get; }
    public string HighSchool { get; }
    public string MaturaType { get; }
    public string DiplomaNumber { get; }
    public string DiplomaIssueDate { get; }
    public string GraduationUni { get; }
    public string University { get; }
    public string Faculty { get; }
    public string Specialization { get; }
    public string OtherUniversity { get; }
    public string WorkExperience { get; }

    public Student(int uid, string name, string secondName, string surname, string course, string index,
        string pesel, string birthdate, string birtPlace, string nip, string sex, string martialStatus,
        string nationality, string citizenship, string id, string idIssuedBy, string passport, string militaryId,
        string motherName, string motherSurname, string fatherName, string fatherSurname, string accountNumber,
        string bankName, string street, string postCode, string town, string post, string mailStreet,
        string mailPostCode, string mailTown, string mailPost, string personalEmail, string email, string landline,
        string mobile, string additional, string maturaId, string maturaDate, int graduationHighSchool,
        string highSchool, string maturaType, string diplomaNumber, string diplomaIssueDate, string graduationUni,
        string university, string faculty, string specialization, string otherUniversity, string workExperience)
    {
        Uid = uid;
        Name = name;
        SecondName = secondName;
        Surname = surname;
        Course = course;
        Index = index;
        Pesel = pesel;
        Birthdate = birthdate;
        BirtPlace = birtPlace;
        Nip = nip;
        Sex = sex;
        MartialStatus = martialStatus;
        Nationality = nationality;
        Citizenship = citizenship;
        Id = id;
        IdIssuedBy = idIssuedBy;
        Passport = passport;
        MilitaryId = militaryId;
        MotherName = motherName;
        MotherSurname = motherSurname;
        FatherName = fatherName;
        FatherSurname = fatherSurname;
        AccountNumber = accountNumber;
        BankName = bankName;
        Street = street;
        PostCode = postCode;
        Town = town;
        Post = post;
        MailStreet = mailStreet;
        MailPostCode = mailPostCode;
        MailTown = mailTown;
        MailPost = mailPost;
        PersonalEmail = personalEmail;
        Email = email;
        Landline = landline;
        Mobile = mobile;
        Additional = additional;
        MaturaId = maturaId;
        MaturaDate = maturaDate;
        GraduationHighSchool = graduationHighSchool;
        HighSchool = highSchool;
        MaturaType = maturaType;
        DiplomaNumber = diplomaNumber;
        DiplomaIssueDate = diplomaIssueDate;
        GraduationUni = graduationUni;
        University = university;
        Faculty = faculty;
        Specialization = specialization;
        OtherUniversity = otherUniversity;
        WorkExperience = workExperience;
    }
}