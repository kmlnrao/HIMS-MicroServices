using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;

using System.Net.Http;

public class BillService
{
    public int BillServiceId { get; set; }
    public int BillId { get; set; }
    public int ServiceId { get; set; }
   // public string ServiceName { get; set; } // Redundant but useful
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    private readonly BillingDbContext _context;
   

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal TotalPrice { get; private set; } // Computed by the database

    


}