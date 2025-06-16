public interface IPaymentService
{
    Task<Payment> CreatePaymentAsync(Payment payment);
    Task<List<Payment>> GetAllPaymentsAsync();
    Task<Payment> GetPaymentByIdAsync(int id);
}