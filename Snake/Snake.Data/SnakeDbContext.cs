namespace Snake.Data
{
    using Microsoft.EntityFrameworkCore;

    using Snake.Data.Models;

    public class SnakeDbContext : DbContext
    {
        public SnakeDbContext()
        {
        }

        public SnakeDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string a = "BojanchO_88";
            a = Guid.NewGuid().ToString();
            optionsBuilder.UseSqlServer($"Server=87.252.185.32, 1433;Database=SnakeGame;User Id=admin;Password={a};TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
               .HasOne(a => a.Settings)
               .WithOne(s => s.Account)
               .HasForeignKey<Settings>(s => s.AccountId);

            modelBuilder.Entity<Account>()
               .HasOne(a => a.Snake)
               .WithOne(s => s.Account)
               .HasForeignKey<Snake>(s => s.AccountId);
        }
    }
}
