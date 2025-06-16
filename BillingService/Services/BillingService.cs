
using Microsoft.EntityFrameworkCore;
public class BillingService : IBillingService
{
    private readonly BillingDbContext _context;
    public BillingService(BillingDbContext context) => _context = context;

    public async Task<Bill> CreateBillAsync(Bill bill)
    {
        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();
        return bill;
    }

    public async Task<Bill> GetBillByIdAsync(int id) =>
        await _context.Bills.Include(b => b.BillServices).FirstOrDefaultAsync(b => b.BillId == id);

    public async Task<List<Bill>> GetAllBillsAsync() =>
        await _context.Bills.Include(b => b.BillServices).ToListAsync();
}