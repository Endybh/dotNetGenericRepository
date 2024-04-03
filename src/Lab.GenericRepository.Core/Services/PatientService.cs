
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
            
            List<Patient> patients = new List<Patient>();

            foreach(var medicalRecord in medicalRecords)
            {
                Patient patient = new Patient(medicalRecord.Patient.Name, medicalRecord.Patient.ContactPhoneNumber, 
                                              medicalRecord.Patient.BirthDate, medicalRecord.Patient.Address, 
                                              medicalRecord.Patient.NamePersonReference, medicalRecord.Patient.PhoneReference);
                patients.Add(patient);
            }
            return patients;
                   
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