using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class Credit : BaseEntity
    {
        public Credit()
        {
            Allocation = new HashSet<Allocation>();
        }

        public int LoanId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public decimal AllocatedAmount { get; set; }
        public int LoanPaymentId { get; set; }
        public string Description { get; set; }

        public virtual Loan Loan { get; set; }
        public virtual ICollection<Allocation> Allocation { get; set; }
    }
}
