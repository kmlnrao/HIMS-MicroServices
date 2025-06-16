using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BillsController : ControllerBase
{
    private readonly IBillingService _service;
    public BillsController(IBillingService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Create(Bill bill) => Ok(await _service.CreateBillAsync(bill));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var bill = await _service.GetBillByIdAsync(id);
        if (bill == null) return NotFound();
        return Ok(bill);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllBillsAsync());
}