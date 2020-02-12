using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class RepaymentPlan
    {
        public RepaymentPlan()
        {
            Debit = new HashSet<Debit>();
        }

        public int Id { get; set; }
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
