using Empresa1.Api.Data.Mappings;
using Empresa1.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Empresa1.Api.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Customer?> Customers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMapping());
        
        base.OnModelCreating(modelBuilder);
    }
}