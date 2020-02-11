using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class City : BaseEntity
    {
        public City()
        {
            Contact = new HashSet<Contact>();
        }

        public string Name { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }
    }
}
