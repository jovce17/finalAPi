using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class Office
    {
        public Office()
        {
            Application = new HashSet<Application>();
            Loan = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Loan> Loan { get; set; }
    }
}
