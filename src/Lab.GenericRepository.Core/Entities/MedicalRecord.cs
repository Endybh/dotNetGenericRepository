namespace Lab.GenericRepository.Core;

public class MedicalRecord:BaseEntity
{
    public DateTime SectionDateHour{get;set;}
    public string SectionDescription{get;set;}
    public Guid PatientFkId{get;set;}
    public Patient Patient{get;set;}
    public Guid ProfessionalFkId{get;set;}
    public Professional Professional{get;set;}
}
