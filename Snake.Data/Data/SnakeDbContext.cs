namespace Snake.Data.Data
{
    using Microsoft.EntityFrameworkCore;

    using Snake.Data.Models;

    public class SnakeDbContext : DbContext
    {
        private readonly string sqlConnectionString;

        public SnakeDbContext(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        DbSet<Snake> Snake { get; set; }

        DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.sqlConnectionString);
            }
        }
    }
}
