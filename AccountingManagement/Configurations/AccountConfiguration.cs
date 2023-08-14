using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AccountingManagement.Entity;

namespace AccountingManagement.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasKey(x => x.Id);
            builder.Property(prop => prop.HolderName)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasComputedColumnSql($"'{DateTime.Now.Year}' + RIGHT('0000000000' + CAST(Id AS VARCHAR(10)), 10)");

            builder.HasMany(prop => prop.Transactions)
                .WithOne(prop => prop.Account);

        }
    }
}
