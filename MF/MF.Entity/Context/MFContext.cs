using System;
using System.Threading.Tasks;
using System.Linq;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MF.Entity.Context
{
    public partial class MFContext : DbContext
    {

        public MFContext(DbContextOptions<MFContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public  DbSet<Allocation> Allocation { get; set; }
        public  DbSet<Application> Application { get; set; }
        public  DbSet<ApplicationApproval> ApplicationApproval { get; set; }
        public  DbSet<BalanceOnDate> BalanceOnDate { get; set; }
        public  DbSet<City> City { get; set; }
        public  DbSet<Contact> Contact { get; set; }
        public  DbSet<Counter> Counter { get; set; }
        public  DbSet<Credit> Credit { get; set; }
        public  DbSet<Debit> Debit { get; set; }
        public  DbSet<Loan> Loan { get; set; }
        public  DbSet<LoanParameter> LoanParameter { get; set; }
        public  DbSet<LoanPayment> LoanPayment { get; set; }
        public  DbSet<LoanStatusChange> LoanStatusChange { get; set; }
        public  DbSet<Office> Office { get; set; }
        public  DbSet<RepaymentPlan> RepaymentPlan { get; set; }
        public  DbSet<Status> Status { get; set; }

        //lazy-loading
        //https://entityframeworkcore.com/querying-data-loading-eager-lazy
        //https://docs.microsoft.com/en-us/ef/core/querying/related-data
        //EF Core will enable lazy-loading for any navigation property that is virtual and in an entity class that can be inherited
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        .UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<User>()
           .HasOne(u => u.Account)
           .WithMany(e => e.Users);

            //concurrency
            modelBuilder.Entity<Account>();
            //    .Property(a => a.RowVersion).IsRowVersion();
            modelBuilder.Entity<User>();
            //    .Property(a => a.RowVersion).IsRowVersion();
            modelBuilder.Entity<Contact>();
        //    .Property(a => a.RowVersion).IsRowVersion();

            //modelBuilder.Entity<User>()
            //.Property(p => p.DecryptedPassword)
            //.HasComputedColumnSql("Uncrypt(p.PasswordText)");
        }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            Audit();
            return await base.SaveChangesAsync();
        }

        private void Audit()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
            //    if (entry.State == EntityState.Added)
            //    {
            //        ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
            //    }
            //((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }

    }
}
