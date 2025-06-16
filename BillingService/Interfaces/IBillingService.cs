public interface IBillingService
{
    Task<Bill> CreateBillAsync(Bill bill);
    Task<Bill> GetBillByIdAsync(int id);
    Task<List<Bill>> GetAllBillsAsync();

    Task<PatientBillDetail?> GetPatientBillDetailsByBillIdAsync(int billId);
    Task<List<PatientBillDetail>> GetPatientBillDetailsByPatientIdAsync(int patientId);

}