using Microsoft.EntityFrameworkCore;

    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentId);

            modelBuilder.Entity<PaymentDetail>()
                .HasKey(pd => pd.PaymentDetailId);

            modelBuilder.Entity<Payment>()
                .HasMany(p => p.PaymentDetails)
                .WithOne()
                .HasForeignKey(pd => pd.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

