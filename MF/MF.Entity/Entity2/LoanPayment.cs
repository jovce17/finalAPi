using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class LoanPayment
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Loan Loan { get; set; }
    }
}
