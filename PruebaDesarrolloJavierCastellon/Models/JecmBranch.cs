using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDesarrolloJavierCastellon.Models
{
    public partial class JecmBranch
    {
        public int IdBranch { get; set; }
        public int Cod { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public string Identification { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Active { get; set; }
        public int? MoneyId { get; set; }

        public virtual JecmMoney Money { get; set; }
    }
}
