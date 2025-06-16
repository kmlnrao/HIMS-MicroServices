using DoctorService.Interfaces;
using DoctorService.Models;
using DoctorService.Data;
using Microsoft.EntityFrameworkCore;

namespace DoctorService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly DoctorDbContext _context;
        public DoctorService(DoctorDbContext context) => _context = context;

        public async Task<Doctor> CreateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
            => await _context.Doctors.FindAsync(id);
    }
}