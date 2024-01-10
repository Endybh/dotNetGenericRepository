namespace Lab.GenericRepository.Core;

public interface IPatientService
{
    Task Include(Patient data);
    Task<List<Patient>> GetMinorPatients();
    Task UpdateInformations(Patient data);
}
