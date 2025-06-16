using Microsoft.EntityFrameworkCore;
using PatientService.Data;
using PatientService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatientService.Services
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;
        public PatientService(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Patient>> GetAllAsync() => await _context.Patients.ToListAsync();

        public async Task<Patient> GetByIdAsync(int id) => await _context.Patients.FindAsync(id);

        public async Task<Patient> AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
    }
}
