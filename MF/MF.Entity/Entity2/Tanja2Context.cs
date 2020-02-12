using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MF.Entity.Entity2
{
    public partial class Tanja2Context : DbContext
    {
        public Tanja2Context()
        {
        }

        public Tanja2Context(DbContextOptions<Tanja2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Allocation> Allocation { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationApproval> ApplicationApproval { get; set; }
        public virtual DbSet<BalanceOnDate> BalanceOnDate { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Counter> Counter { get; set; }
        public virtual DbSet<Credit> Credit { get; set; }
        public virtual DbSet<Debit> Debit { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<LoanParameter> LoanParameter { get; set; }
        public virtual DbSet<LoanPayment> LoanPayment { get; set; }
        public virtual DbSet<LoanStatusChange> LoanStatusChange { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<RepaymentPlan> RepaymentPlan { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HGLV3CG;Database=Tanja2;Trusted_Connection=True;Integrated Security=true;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Allocation>(entity =>
            {
                entity.Property(e => e.AllocatedAmount).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.CreditId).HasColumnName("CreditID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DebitId).HasColumnName("DebitID");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.HasOne(d => d.Credit)
                    .WithMany(p => p.Allocation)
                    .HasForeignKey(d => d.CreditId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Allocation_Credit");

                entity.HasOne(d => d.Debit)
                    .WithMany(p => p.Allocation)
                    .HasForeignKey(d => d.DebitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Allocation_Debit");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Allocation)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Allocation_Loan");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.Property(e => e.ApplicationDate).HasColumnType("date");

                entity.Property(e => e.ApplicationFee).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.ApplicationNumber)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ApprovedAmount).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.ClientContactId).HasColumnName("ClientContactID");

                entity.Property(e => e.InterestRate).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.LoanOfficerContactId).HasColumnName("LoanOfficerContactID");

                entity.Property(e => e.OfficeId).HasColumnName("OfficeID");

                entity.Property(e => e.RequestedAmount).HasColumnType("decimal(9, 2)");

                entity.HasOne(d => d.ClientContact)
                    .WithMany(p => p.ApplicationClientContact)
                    .HasForeignKey(d => d.ClientContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_ClientContact");

                entity.HasOne(d => d.LoanOfficerContact)
                    .WithMany(p => p.ApplicationLoanOfficerContact)
                    .HasForeignKey(d => d.LoanOfficerContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_LoanOfficerContact");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Application_Office");
            });

            modelBuilder.Entity<ApplicationApproval>(entity =>
            {
                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.DecisionDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationApproval)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationApproval_Application");
            });

            modelBuilder.Entity<BalanceOnDate>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DueInterest).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.DuePrincipal).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.LastPayment).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.LastPaymentDate).HasColumnType("date");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.PaidInterest).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.PaidPrincipal).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Prepaid).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.TotalInterest).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.TotalPrincipal).HasColumnType("decimal(9, 2)");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.BalanceOnDate)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BalanceOnDate_Loan");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.IdcardNumber)
                    .HasColumnName("IDCardNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(500);

                entity.Property(e => e.Uid)
                    .IsRequired()
                    .HasColumnName("UID")
                    .HasMaxLength(20);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Contact_City");
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Counter1).HasColumnName("Counter");

                entity.Property(e => e.CounterCode).HasMaxLength(10);

                entity.Property(e => e.Year).HasMaxLength(4);
            });

            modelBuilder.Entity<Credit>(entity =>
            {
                entity.Property(e => e.AllocatedAmount).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Amount).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.LoanPaymentId).HasColumnName("LoanPaymentID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Credit)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Credit_Loan");
            });

            modelBuilder.Entity<Debit>(entity =>
            {
                entity.Property(e => e.AllocatedAmount).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Amount).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.RepaymentKeyId).HasColumnName("RepaymentKeyID");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Debit)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Debit_Loan");

                entity.HasOne(d => d.RepaymentKey)
                    .WithMany(p => p.Debit)
                    .HasForeignKey(d => d.RepaymentKeyId)
                    .HasConstraintName("FK_Debit_RepaymentPlanID");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.AgreementDate).HasColumnType("date");

                entity.Property(e => e.AgreementNumber)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Amount).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.ApplicationFee).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.ClientContactId).HasColumnName("ClientContactID");

                entity.Property(e => e.ClosingDate).HasColumnType("date");

                entity.Property(e => e.DisbursementDate).HasColumnType("date");

                entity.Property(e => e.InterestRate).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.LoanOfficerContactId).HasColumnName("LoanOfficerContactID");

                entity.Property(e => e.MaturityDate).HasColumnType("date");

                entity.Property(e => e.OfficeId).HasColumnName("OfficeID");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_Application");

                entity.HasOne(d => d.ClientContact)
                    .WithMany(p => p.LoanClientContact)
                    .HasForeignKey(d => d.ClientContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_ClientContact");

                entity.HasOne(d => d.LoanOfficerContact)
                    .WithMany(p => p.LoanLoanOfficerContact)
                    .HasForeignKey(d => d.LoanOfficerContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_LoanOfficerContact");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loan_Office");
            });

            modelBuilder.Entity<LoanParameter>(entity =>
            {
                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.Parameter1).HasMaxLength(50);

                entity.Property(e => e.Parameter2).HasMaxLength(50);
            });

            modelBuilder.Entity<LoanPayment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.LoanPayment)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoanPayment_Contact");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.LoanPayment)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoanPayment_Loan");
            });

            modelBuilder.Entity<LoanStatusChange>(entity =>
            {
                entity.Property(e => e.DecisionDate).HasColumnType("date");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Office)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Office_City");
            });

            modelBuilder.Entity<RepaymentPlan>(entity =>
            {
                entity.Property(e => e.Interest).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.LoanId).HasColumnName("LoanID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.Principal).HasColumnType("decimal(9, 2)");

                entity.Property(e => e.TotalInstallment).HasColumnType("decimal(9, 2)");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.RepaymentPlan)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RepaymentPlan_Loan");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Status1).HasColumnName("Status");

                entity.Property(e => e.Table).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.UserName).HasMaxLength(10);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.AccountId);

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Roles).HasMaxLength(255);

                entity.Property(e => e.RowVersion)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UserName).HasMaxLength(30);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccountId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
