public class BillService
{
    public int BillServiceId { get; set; }
    public int BillId { get; set; }
    public int ServiceId { get; set; }
    public string ServiceName { get; set; } // Redundant but useful
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}