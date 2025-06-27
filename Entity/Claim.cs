using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime DateFiled { get; set; }
        public decimal ClaimAmount { get; set; }
        public string Status { get; set; }

        public int PolicyId { get; set; }
        public Policy Policy { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
