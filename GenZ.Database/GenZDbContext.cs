using Microsoft.EntityFrameworkCore;

namespace GenZ.Database
{
    public class GenZDbContext : DbContext
    {
        public GenZDbContext(DbContextOptions<GenZDbContext> context) : base(context)
        {
            
        }

        public GenZDbContext()
        {

        }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                "Server=UPSDJ;Database=GenZDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }
    }
}
