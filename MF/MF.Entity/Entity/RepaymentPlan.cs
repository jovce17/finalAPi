using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class RepaymentPlan : BaseEntity
    {
        public RepaymentPlan()
        {
            Debit = new HashSet<Debit>();
        }

        public int LoanId { get; set; }
        public int InstallmentsNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal TotalInstallment { get; set; }

        public virtual Loan Loan { get; set; }
        public virtual ICollection<Debit> Debit { get; set; }
    }
}
