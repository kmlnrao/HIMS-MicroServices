
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

public class BillingService : IBillingService
{
    private readonly BillingDbContext _context;
    public BillingService(BillingDbContext context) => _context = context;
    private readonly IHttpClientFactory _httpClientFactory;

    public BillingService(BillingDbContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClientFactory = httpClientFactory;
    }



    public async Task<List<PatientBillDetail>> GetPatientBillDetailsByPatientIdAsync(int patientId)
    {
        var bills = await _context.Bills
            .Include(b => b.BillServices)
            .Where(b => b.PatientId == patientId)
            .ToListAsync();
        if (!bills.Any()) return new();

        var patient = await _httpClientFactory.CreateClient()
            .GetFromJsonAsync<PatientDto>($"http://localhost:5001/api/patients/{patientId}");

        var results = new List<PatientBillDetail>();
        foreach (var bill in bills)
        {
            var payments = await _httpClientFactory.CreateClient()
                .GetFromJsonAsync<List<PaymentDto>>($"http://localhost:5004/api/payments/bybill/{bill.BillId}");

            results.Add(new PatientBillDetail
            {
                BillInfo = bill,
                PatientInfo = patient,
                PaymentInfo = payments
            });
        }

        return results;
    }
    public async Task<Bill> CreateBillAsync(Bill bill)
    {
        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();
        return bill;
    }

    public async Task<string> GetPatientDetailsAsync(int patientId)
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5001/api/Patients/{patientId}");
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<PatientBillDetail?> GetPatientBillDetailsByBillIdAsync(int billId)
    {
        var bill = await _context.Bills
            .Include(b => b.BillServices)
            .FirstOrDefaultAsync(b => b.BillId == billId);
        if (bill == null) return null;

        var patient = await _httpClientFactory.CreateClient()
            .GetFromJsonAsync<PatientDto>($"http://localhost:5001/api/patients/{bill.PatientId}");

        var payments = await _httpClientFactory.CreateClient()
            .GetFromJsonAsync<List<PaymentDto>>($"http://localhost:5004/api/payments/bybill/{billId}");

        return new PatientBillDetail
        {
            BillInfo = bill,
            PatientInfo = patient,
            PaymentInfo = payments
        };
    }

    public async Task<Bill> GetBillByIdAsync(int id) =>
        await _context.Bills.Include(b => b.BillServices).FirstOrDefaultAsync(b => b.BillId == id);

    public async Task<List<Bill>> GetAllBillsAsync() =>
        await _context.Bills.Include(b => b.BillServices).ToListAsync();
}