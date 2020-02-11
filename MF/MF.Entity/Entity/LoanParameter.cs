using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class LoanParameter : BaseEntity
    {
        public int LoanId { get; set; }
        public int? RowNo { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
    }
}
