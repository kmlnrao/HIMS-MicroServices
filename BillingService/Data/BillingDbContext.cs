using Microsoft.EntityFrameworkCore;

public class BillingDbContext : DbContext
{
    public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options) { }

    public DbSet<Bill> Bills { get; set; }
    public DbSet<BillService> BillServices { get; set; }
}