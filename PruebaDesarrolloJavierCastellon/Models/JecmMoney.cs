using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDesarrolloJavierCastellon.Models
{
    public partial class JecmMoney
    {
        public JecmMoney()
        {
            JecmBranches = new HashSet<JecmBranch>();
        }

        public int IdMoney { get; set; }
        public string Cod { get; set; }
        public string Abbreviation { get; set; }
        public string Symbol { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<JecmBranch> JecmBranches { get; set; }
    }
}
