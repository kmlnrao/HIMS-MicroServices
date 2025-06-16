public class PatientBillDetail
{
    public Bill BillInfo { get; set; }
    public PatientDto PatientInfo { get; set; }
    public List<BillServiceDto> BillServices { get; set; }
    public List<PaymentDto> PaymentInfo { get; set; }
}


public class PatientDto
{
    public int PatientId { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string Phone { get; set; }
}

public class BillServiceDto
{
    public int ServiceId { get; set; }
    public string ServiceName { get; set; }   // Optional - if fetched from service DB
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}

public class PaymentDto
{
    public int PaymentId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal TotalPaidAmount { get; set; }
    public List<PaymentDetailDto> PaymentDetails { get; set; }
}

public class PaymentDetailDto
{
    public int BillId { get; set; }
    public decimal PaidAmount { get; set; }
    public string PayMode { get; set; }
    public string ReferenceNo { get; set; }
}
