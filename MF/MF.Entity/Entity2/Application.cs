using System;
using System.Collections.Generic;

namespace MF.Entity.Entity2
{
    public partial class Application
    {
        public Application()
        {
            ApplicationApproval = new HashSet<ApplicationApproval>();
            Loan = new HashSet<Loan>();
        }

        public int Id { get; set; }
        public string ApplicationNumber { get; set; }
        public int ClientContactId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int LoanOfficerContactId { get; set; }
        public int OfficeId { get; set; }
        public short Status { get; set; }
        public decimal? RequestedAmount { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public int? RequestedInstallments { get; set; }
        public int? ApprovedInstallments { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? ApplicationFee { get; set; }

        public virtual Contact ClientContact { get; set; }
        public virtual Contact LoanOfficerContact { get; set; }
        public virtual Office Office { get; set; }
        public virtual ICollection<ApplicationApproval> ApplicationApproval { get; set; }
        public virtual ICollection<Loan> Loan { get; set; }
    }
}
