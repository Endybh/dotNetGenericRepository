
using System.Linq;

namespace Lab.GenericRepository.Core
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;
        private readonly IRepository<MedicalRecord> _medicalRecordRepository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<List<Patient>> GetMinorPatients()
        {
            return await _patientRepository.SelectAsync(p=>p.BirthDate.Year > DateTime.Now.Date.AddYears(-18).Year);
        }

        public async Task<List<Patient>> GetPatientsThanNoLongTimePsychologySection()
        {
            var medicalRecords = await _medicalRecordRepository.SelectAsync(mr=>(mr.SectionDateHour - DateTime.Now).Days > 7);
            
            return medicalRecords.Select(m => new Patient
            {
                Address = m.Patient.Address,
                BirthDate = m.Patient.BirthDate,
                ContactPhoneNumber = m.Patient.ContactPhoneNumber,
                Name = m.Patient.Name,
                NamePersonReference = m.Patient.NamePersonReference,
                PhoneReference = m.Patient.PhoneReference
            }).ToList();
                   
        }

        public async Task Include(Patient data)
        {
            await _patientRepository.AddAsync(data);
        }

        public async Task UpdateInformations(Patient data)
        {
            await _patientRepository.UpdateAsync(data);
        }
    }
}