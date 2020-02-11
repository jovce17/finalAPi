using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class ApplicationApproval : BaseEntity
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public short? Status { get; set; }
        public DateTime? DecisionDate { get; set; }

        public virtual Application Application { get; set; }
    }
}
