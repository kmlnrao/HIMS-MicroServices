using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
public class PaymentService : IPaymentService
{
    private readonly PaymentDbContext _context;
    public PaymentService(PaymentDbContext context) => _context = context;

    public async Task<Payment> CreatePaymentAsync(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<List<Payment>> GetAllPaymentsAsync()
        => await _context.Payments.Include(p => p.PaymentDetails).ToListAsync();

    public async Task<Payment> GetPaymentByIdAsync(int id)
        => await _context.Payments.Include(p => p.PaymentDetails).FirstOrDefaultAsync(p => p.PaymentId == id);
}