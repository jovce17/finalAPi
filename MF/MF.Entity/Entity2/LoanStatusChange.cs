using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class LoanStatusChange
    {
        public int Id { get; set; }
        public int? LoanId { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }
        public DateTime? DecisionDate { get; set; }
    }
}
