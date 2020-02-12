using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class LoanParameter
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int? RowNo { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
    }
}
