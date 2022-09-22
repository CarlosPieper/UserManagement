using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Model;

namespace UserManagement.Persistence;
public class MsSqlContext : DbContext
{
    public MsSqlContext() { }
    public MsSqlContext(DbContextOptions<MsSqlContext> option) : base(option) { }
    public DbSet<City> Cities { get; set; }
    public DbSet<Person> People { get; set; }
}
