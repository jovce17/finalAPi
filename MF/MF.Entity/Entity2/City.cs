using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class City
    {
        public City()
        {
            Contact = new HashSet<Contact>();
            Office = new HashSet<Office>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<Office> Office { get; set; }
    }
}
