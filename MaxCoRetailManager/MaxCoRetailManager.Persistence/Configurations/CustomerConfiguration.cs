using MaxCoRetailManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxCoRetailManager.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        //primary key
        builder.HasKey(c => c.Id);

        //set properties
        builder.Property(c => c.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(c => c.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(c => c.PhoneNumber)
            .HasMaxLength(19);

        builder.Property(c => c.CreatedBy)
            .HasMaxLength(450);

        //foreign key to user
        //builder.HasOne(c => c.User)
        //    .WithMany(u => u.Customers)
        //    .HasForeignKey(c => c.CreatedBy)
        //    .OnDelete(DeleteBehavior.ClientSetNull);




    }
}
