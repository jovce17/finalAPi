using System;
using System.Collections.Generic;

namespace MF.Entity
{
    public partial class Contact : BaseEntity
    {
        //public Contact()
        //{
        //    //ApplicationClientContact = new HashSet<Application>();
        //    //ApplicationLoanOfficerContact = new HashSet<Application>();
        //    //LoanClientContact = new HashSet<Loan>();
        //    //LoanLoanOfficerContact = new HashSet<Loan>();
        //    //LoanPayment = new HashSet<LoanPayment>();
        //}

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Uid { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdcardNumber { get; set; }
        public short? MaritialStatus { get; set; }
        public int? ContactType { get; set; }
        public bool? Employee { get; set; }

        public virtual City City { get; set; }
        //public virtual ICollection<Application> ApplicationClientContact { get; set; }
        //public virtual ICollection<Application> ApplicationLoanOfficerContact { get; set; }
        //public virtual ICollection<Loan> LoanClientContact { get; set; }
        //public virtual ICollection<Loan> LoanLoanOfficerContact { get; set; }
        //public virtual ICollection<LoanPayment> LoanPayment { get; set; }
    }
}
