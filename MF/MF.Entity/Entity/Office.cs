using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class Office : BaseEntity
    {
        public Office()
        {
            Application = new HashSet<Application>();
            Loan = new HashSet<Loan>();
        }

        public string Name { get; set; }
        public int? CityId { get; set; }

        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Loan> Loan { get; set; }
    }
}
