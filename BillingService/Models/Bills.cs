public class Bill
{
    public int BillId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime BillDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<BillService> BillServices { get; set; }
}