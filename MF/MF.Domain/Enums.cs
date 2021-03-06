﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MF.Domain
{
    public class Enums
    {
        public enum Gender
        {
            Male = 1,
            Female = 2
        }
        public enum MaritialStatus
        {
            Single = 1,
            Merried = 2

        }
        public enum ContactType
        {
            Person = 1,
            Company = 2

        }
        public enum ApplicationStatus
        {
            New = 1,
            Approved = 2,
            Rejected=3

        }
        public enum ApplicationApprovalStatus
        {
            NotDecided=0,
            Approved = 1,
            Rejected = 2

        }
        public enum LoanStatus
        {
            New = 1,
            Repayment = 2,
            Closed = 3

        }
    }
}
