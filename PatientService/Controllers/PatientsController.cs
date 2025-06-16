using Microsoft.AspNetCore.Mvc;
using PatientService.Models;
using PatientService.Services;
using System.Threading.Tasks;

namespace PatientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _service.GetByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  Patient patient)
        { 
            var created = await _service.AddAsync(patient);
            return CreatedAtAction(nameof(GetById), new { id = created.PatientId }, created);
        }
        
    }
}
