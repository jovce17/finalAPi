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
    public class ApplicationViewModel : BaseDomain
    {

        public string ApplicationNumber { get; set; }


        public KeyValueGeneric<int, string> ClientContact = new KeyValueGeneric<int, string>();

        public DateTime ApplicationDate { get; set; }

        public KeyValueGeneric<int, string> LoanOfficerContact = new KeyValueGeneric<int, string>();

        public KeyValueGeneric<int, string> Office = new KeyValueGeneric<int, string>();

        public KeyValueGeneric<int, string> Status = new KeyValueGeneric<int, string>();
        public decimal? RequestedAmount { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public int? RequestedInstallments { get; set; }
        public int? ApprovedInstallments { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? ApplicationFee { get; set; }

        [JsonIgnore]  //to avoid circular serialization 
        public virtual CityViewModel CityV { get; set; }
    }
}
