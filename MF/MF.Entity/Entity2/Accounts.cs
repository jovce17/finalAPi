using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class Accounts
    {
        public Accounts()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }
        public DateTime SetActive { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
