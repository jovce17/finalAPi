using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class ApplicationApproval
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public short? Status { get; set; }
        public DateTime? DecisionDate { get; set; }

        public virtual Application Application { get; set; }
    }
}
