public class Payment
{
    public int PaymentId { get; set; }
    public int PatientId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal TotalPaidAmount { get; set; }
    public List<PaymentDetail> PaymentDetails { get; set; }
}