using Microsoft.EntityFrameworkCore;

namespace MyFirstEfCoreApp;

public class AppDbContext : DbContext
{
    private const string connectionString = 
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyFirstEfCoreApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Trusted_Connection=True";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Book> Books { get; set; } = default!;
}
