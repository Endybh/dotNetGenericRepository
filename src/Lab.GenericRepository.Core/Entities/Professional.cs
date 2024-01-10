namespace Lab.GenericRepository.Core
{
    public class Professional:BaseEntity
    {
        public string Name{get;set;}
        public string Specialty{get;set;}
        public string RegistrationCouncil{get;set;}
        public string ProfessionalRegisterNumber{get;set;}
        public virtual ICollection<MedicalRecord> MedicalRecords{get;set;}
    }
}