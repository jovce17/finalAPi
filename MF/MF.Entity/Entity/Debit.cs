﻿using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class Debit : BaseEntity
    {
        public Debit()
        {
            Allocation = new HashSet<Allocation>();
        }

        public int LoanId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? InstallmentNo { get; set; }
        public short? DebitType { get; set; }
        public decimal Amount { get; set; }
        public decimal? AllocatedAmount { get; set; }
        public int? RepaymentKeyId { get; set; }
        public string Description { get; set; }

        public virtual Loan Loan { get; set; }
        public virtual RepaymentPlan RepaymentKey { get; set; }
        public virtual ICollection<Allocation> Allocation { get; set; }
    }
}
