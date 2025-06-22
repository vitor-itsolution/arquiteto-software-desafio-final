using Empresa1.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa1.Api.Data.Mappings;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Phone).HasMaxLength(10).IsRequired();
        builder.Property(c => c.Address).HasMaxLength(100).IsRequired();    
        builder.Property(c => c.CreatedAt).IsRequired();
        
        builder.ToTable("Customers");
    }
}