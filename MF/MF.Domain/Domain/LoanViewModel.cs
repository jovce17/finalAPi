using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace MF.Domain
{
    /// <summary>
    /// A user attached to an account
    /// </summary>
    public class LoanViewModel : BaseDomain
    {

        public string AgreementNumber { get; set; }
        public DateTime AgreementDate { get; set; }

        public KeyValueGeneric<int, string> Application = new KeyValueGeneric<int, string>();

        public KeyValueGeneric<int, string> LoanOfficerContact = new KeyValueGeneric<int, string>();

        public KeyValueGeneric<int, string> Office = new KeyValueGeneric<int, string>();

        public KeyValueGeneric<int, string> ClientContact = new KeyValueGeneric<int, string>();
        public decimal Amount { get; set; }
        public int Installments { get; set; }

        public KeyValueGeneric<short, string> Status = new KeyValueGeneric<short, string>();
        public decimal InterestRate { get; set; }
        public decimal? ApplicationFee { get; set; }
        public DateTime? DisbursementDate { get; set; }
        public DateTime? MaturityDate { get; set; }
        public DateTime? ClosingDate { get; set; }

    }
}
