using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MF.Domain
{
    public class BaseDomain
    {
        public int Id { get; set; }
    }
    public class KeyValueGeneric<t,y>
    {
        public t Id { get; set; }
        public y Value { get; set; }
    }
}
