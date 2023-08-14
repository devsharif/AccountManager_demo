using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Drawing;
using AccountingManagement.Entity;
using Microsoft.EntityFrameworkCore;
using AccountingManagement.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace AccountingManagement.Data
{
    public partial class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContext;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContext) : base(options)
        {
            _httpContext = httpContext;
        }

        public DbSet<Account> Accounts  { get; set; }
        public DbSet<Transaction> Transactions  { get; set; }

        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().Property(prop => prop.CreatedBy)
                .HasMaxLength(256);

            builder.Entity<T>().Property(prop => prop.LastModifiedBy)
                .HasMaxLength(256);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public async Task<int> SaveChangesAsync()
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync();
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {

                if (entry.Entity is BaseEntity baseEntity)
                {
                    var now = DateTime.Now;
                    //var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            baseEntity.LastModifiedDate = now;
                            baseEntity.LastModifiedBy = "demo_admin";
                            break;

                        case EntityState.Added:
                            baseEntity.CreatedDate = now;
                            baseEntity.CreatedBy = "demo_admin";
                            baseEntity.LastModifiedDate = now;
                            baseEntity.LastModifiedBy = "demo_admin";
                            break;
                    }
                }
            }
        }
    }
}
