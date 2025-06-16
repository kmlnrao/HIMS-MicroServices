using PatientService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientService.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> AddAsync(Patient patient);
    }
}
