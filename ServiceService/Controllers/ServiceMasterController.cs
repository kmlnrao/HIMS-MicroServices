using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ServiceMasterController : ControllerBase
{
    private readonly IServiceMasterService _service;
    public ServiceMasterController(IServiceMasterService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ServiceMaster model) => Ok(await _service.CreateAsync(model));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}