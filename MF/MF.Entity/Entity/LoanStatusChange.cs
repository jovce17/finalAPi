using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class LoanStatusChange : BaseEntity
    {
        public int? LoanId { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }
        public DateTime? DecisionDate { get; set; }
    }
}
