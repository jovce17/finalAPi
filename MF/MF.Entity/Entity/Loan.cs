using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class Loan : BaseEntity
    {
        public Loan()
        {
            Allocation = new HashSet<Allocation>();
            BalanceOnDate = new HashSet<BalanceOnDate>();
            Credit = new HashSet<Credit>();
            Debit = new HashSet<Debit>();
            LoanPayment = new HashSet<LoanPayment>();
            RepaymentPlan = new HashSet<RepaymentPlan>();
        }

        public string AgreementNumber { get; set; }
        public DateTime AgreementDate { get; set; }
        public int ApplicationId { get; set; }
        public int LoanOfficerContactId { get; set; }
        public int OfficeId { get; set; }
        public int ClientContactId { get; set; }
        public decimal Amount { get; set; }
        public int Installments { get; set; }
        public short Status { get; set; }
        public decimal InterestRate { get; set; }
        public decimal? ApplicationFee { get; set; }
        public DateTime? DisbursementDate { get; set; }
        public DateTime? MaturityDate { get; set; }
        public DateTime? ClosingDate { get; set; }

        public virtual Application Application { get; set; }
        public virtual Contact ClientContact { get; set; }
        public virtual Contact LoanOfficerContact { get; set; }
        public virtual Office Office { get; set; }
        public virtual ICollection<Allocation> Allocation { get; set; }
        public virtual ICollection<BalanceOnDate> BalanceOnDate { get; set; }
        public virtual ICollection<Credit> Credit { get; set; }
        public virtual ICollection<Debit> Debit { get; set; }
        public virtual ICollection<LoanPayment> LoanPayment { get; set; }
        public virtual ICollection<RepaymentPlan> RepaymentPlan { get; set; }
    }
}
