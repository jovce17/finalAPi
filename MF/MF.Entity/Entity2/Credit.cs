using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class Credit
    {
        public Credit()
        {
            Allocation = new HashSet<Allocation>();
        }

        public int Id { get; set; }
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
