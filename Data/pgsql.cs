using dotnet_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class npgsqlCon : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=dotnet-mvc;User Id=postgres;Port=5432;Password=Syx@2022;");//String de conexão pgsql.
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}