using Microsoft.EntityFrameworkCore;

public class ServicesDbContext : DbContext
{
    public ServicesDbContext(DbContextOptions<ServicesDbContext> options) : base(options) { }
    public DbSet<ServiceMaster> ServiceMasters { get; set; }
}