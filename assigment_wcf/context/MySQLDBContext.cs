   using baseNetApi.models;
using Microsoft.EntityFrameworkCore;

namespace baseNetApi.context;

public class MySQLDBContext : DbContext
{
    public DbSet<ContactName> ContactName { get; set; }
    public DbSet<ContactNumber> ContactNumber { get; set; }
    public DbSet<GroupName> GroupName{ get; set; }
    
    public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
}