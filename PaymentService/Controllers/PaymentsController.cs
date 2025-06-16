using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _service;
    public PaymentsController(IPaymentService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Create(Payment payment) => Ok(await _service.CreatePaymentAsync(payment));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllPaymentsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => Ok(await _service.GetPaymentByIdAsync(id));
}