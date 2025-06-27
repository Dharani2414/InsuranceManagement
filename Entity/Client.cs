using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public  class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Contactinfo {  get; set; }
        public int PolicyId {  get; set; }
        public Policy Policy { get; set; }
        public ICollection<Claim> Claims { get; set; }
        public ICollection<PaymentDetails> PaymentDetails { get; set; }
    }
}
