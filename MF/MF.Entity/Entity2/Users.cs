using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class Users
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool IsAdminRole { get; set; }
        public string Roles { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public int AccountId { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Accounts Account { get; set; }
    }
}
