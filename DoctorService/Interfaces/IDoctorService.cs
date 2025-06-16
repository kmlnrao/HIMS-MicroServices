using DoctorService.Models;
using System.Threading.Tasks;

namespace DoctorService.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> CreateDoctorAsync(Doctor doctor);
        Task<Doctor> GetDoctorByIdAsync(int id);
    }
}