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
    public class RepaymentPlanViewModel : BaseDomain
    {

        public KeyValueGeneric<int, string> Loan = new KeyValueGeneric<int, string>();
        public int InstallmentsNo { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal TotalInstallment { get; set; }


    }
}
