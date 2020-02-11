using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class Allocation : BaseEntity
    {
        public int LoanId { get; set; }
        public DateTime Date { get; set; }
        public int DebitId { get; set; }
        public int CreditId { get; set; }
        public decimal AllocatedAmount { get; set; }

        public virtual Credit Credit { get; set; }
        public virtual Debit Debit { get; set; }
        public virtual Loan Loan { get; set; }
    }
}
