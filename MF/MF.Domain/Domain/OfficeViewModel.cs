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
    public class OfficeViewModel : BaseDomain
    {

        public string Name { get; set; }
        public KeyValueGeneric<int?, string> City = new KeyValueGeneric<int?, string>();

    }
}
