using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class Status : BaseEntity
    {
        public string Table { get; set; }
        public int? Status1 { get; set; }
        public string Description { get; set; }
    }
}
