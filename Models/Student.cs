namespace WSEIDziekanat.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SecondName { get; set; }
    public string Surname { get; set; }
    public string Course { get; set; }
    public string Index { get; set; }
    public string Pesel { get; set; }
    public string Birthdate { get; set; }
    public string BirtPlace { get; set; }
    public string Nip { get; set; }
    public string Sex { get; set; }
    public string MartialStatus { get; set; }
    public string Nationality { get; set; }
    public string Citizenship { get; set; }
    public string IdNumber { get; set; }
    public string IdIssuedBy { get; set; }
    public string Passport { get; set; }
    public string MilitaryId { get; set; }
    public string MotherName { get; set; }
    public string MotherSurname { get; set; }
    public string FatherName { get; set; }
    public string FatherSurname { get; set; }
    public string AccountNumber { get; set; }
    public string BankName { get; set; }
    public string Street { get; set; }
    public string PostCode { get; set; }
    public string Town { get; set; }
    public string Post { get; set; }
    public string MailStreet { get; set; }
    public string MailPostCode { get; set; }
    public string MailTown { get; set; }
    public string MailPost { get; set; }
    public string PersonalEmail { get; set; }
    public string Email { get; set; }
    public string Landline { get; set; }
    public string Mobile { get; set; }
    public string Additional { get; set; }
    public string MaturaId { get; set; }
    public string MaturaDate { get; set; }
    public int GraduationHighSchool { get; set; }
    public string HighSchool { get; set; }
    public string MaturaType { get; set; }
    public string DiplomaNumber { get; set; }
    public string DiplomaIssueDate { get; set; }
    public string GraduationUni { get; set; }
    public string University { get; set; }
    public string Faculty { get; set; }
    public string Specialization { get; set; }
    public string OtherUniversity { get; set; }
    public string WorkExperience { get; set; }

    public Student(int id, string name, string secondName, string surname, string course, string index,
        string pesel, string birthdate, string birtPlace, string nip, string sex, string martialStatus,
        string nationality, string citizenship, string idNumber, string idIssuedBy, string passport, string militaryId,
        string motherName, string motherSurname, string fatherName, string fatherSurname, string accountNumber,
        string bankName, string street, string postCode, string town, string post, string mailStreet,
        string mailPostCode, string mailTown, string mailPost, string personalEmail, string email, string landline,
        string mobile, string additional, string maturaId, string maturaDate, int graduationHighSchool,
        string highSchool, string maturaType, string diplomaNumber, string diplomaIssueDate, string graduationUni,
        string university, string faculty, string specialization, string otherUniversity, string workExperience)
    {
        Id = id;
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
        IdNumber = idNumber;
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