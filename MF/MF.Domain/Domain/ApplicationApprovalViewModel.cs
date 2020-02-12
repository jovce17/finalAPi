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
    public class ApplicationApprovalViewModel : BaseDomain
    {

        public KeyValueGeneric<int, string> Application = new KeyValueGeneric<int, string>();
        public KeyValueGeneric<int, string> User = new KeyValueGeneric<int, string>();

        public KeyValueGeneric<short?, string> Status = new KeyValueGeneric<short?, string>();
        public DateTime? DecisionDate { get; set; }

    }
}
