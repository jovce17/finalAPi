using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class BalanceOnDate : BaseEntity
    {
        public DateTime Date { get; set; }
        public int LoanId { get; set; }
        public decimal? TotalPrincipal { get; set; }
        public decimal? DuePrincipal { get; set; }
        public decimal? PaidPrincipal { get; set; }
        public decimal? TotalInterest { get; set; }
        public decimal? DueInterest { get; set; }
        public decimal? PaidInterest { get; set; }
        public decimal? Prepaid { get; set; }
        public decimal? LastPayment { get; set; }
        public DateTime? LastPaymentDate { get; set; }

        public virtual Loan Loan { get; set; }
    }
}
