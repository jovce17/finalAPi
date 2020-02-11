using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class LoanPayment : BaseEntity
    {
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Loan Loan { get; set; }
    }
}
