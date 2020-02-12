using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int? ContactId { get; set; }
    }
}
