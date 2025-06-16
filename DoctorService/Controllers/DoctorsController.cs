using DoctorService.Models;
using DoctorService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _service;
        public DoctorsController(IDoctorService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor) => Ok(await _service.CreateDoctorAsync(doctor));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _service.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
        }
    }
}