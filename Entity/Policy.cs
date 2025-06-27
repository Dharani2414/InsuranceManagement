using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public string PolicyType { get; set; }
        public decimal CoverageAmount { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Claim> Claims { get; set; }



    }
}
