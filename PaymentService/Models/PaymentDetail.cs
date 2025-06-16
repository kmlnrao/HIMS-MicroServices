public class PaymentDetail
{
    public int PaymentDetailId { get; set; }
    public int PaymentId { get; set; }
    public int BillId { get; set; }
    public decimal PaidAmount { get; set; }
    public string PayMode { get; set; }
    public string ReferenceNo { get; set; }
}