namespace Lab.GenericRepository.Core;

public class Patient:BaseEntity
{
    public string Name{get;}
    public string ContactPhoneNumber{get;}
    public DateTime BirthDate{get;}
    public string Address{get;}
    public string NamePersonReference{get;}
    public string PhoneReference{get;}

    public Patient(string name, string contactPhoneNumber, DateTime birthDate, string address, 
                   string namePersonReference, string phonePersonReference)
    {
        Id = Guid.NewGuid();
        Name = name;
        ContactPhoneNumber = contactPhoneNumber;
        BirthDate = birthDate;
        Address = address;
        NamePersonReference = namePersonReference;
        PhoneReference = phonePersonReference;

        Validate(this, new PatientValidator());
    }
}
