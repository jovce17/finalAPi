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
    public class ContactViewModel : BaseDomain
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Uid { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }

        public KeyValueGeneric<int?, string> City = new KeyValueGeneric<int?, string>();
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IdcardNumber { get; set; }

        public KeyValueGeneric<int?, string> MaritialStatus = new KeyValueGeneric<int?, string>();

        public KeyValueGeneric<int?, string> ContactType = new KeyValueGeneric<int?, string>();
        public bool? Employee { get; set; }

        [JsonIgnore]  //to avoid circular serialization 
        public virtual CityViewModel CityV { get; set; }
    }
}
