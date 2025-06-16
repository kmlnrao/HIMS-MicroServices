using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BillsController : ControllerBase
{

    private readonly IBillingService _billingService;

    
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


    [HttpGet("details")]
public async Task<IActionResult> GetDetails([FromQuery] int? billId, [FromQuery] int? patientId)
{
    if (billId.HasValue)
    {
        var result = await _billingService.GetPatientBillDetailsByBillIdAsync(billId.Value);
        if (result == null) return NotFound("No bill found.");
        return Ok(result);
    }
    else if (patientId.HasValue)
    {
        var result = await _billingService.GetPatientBillDetailsByPatientIdAsync(patientId.Value);
        if (result == null || result.Count == 0) return NotFound("No bills found for patient.");
        return Ok(result);
    }

    return BadRequest("Provide either a billId or patientId.");
}

}