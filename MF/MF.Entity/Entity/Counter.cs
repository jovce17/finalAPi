using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class Counter : BaseEntity
    {
        public string CounterCode { get; set; }
        public int? Counter1 { get; set; }
        public string Year { get; set; }
    }
}
