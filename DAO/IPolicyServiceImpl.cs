using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class IPolicyServiceImpl : IPolicyService
    {
        private readonly InsuranceDBContext _context;

        public IPolicyServiceImpl(InsuranceDBContext context) => _context = context;

        public bool AddPolicy(Policy policy)
        {
            _context.Policies.Add(policy);
            return _context.SaveChanges() > 0;
        }

        public Policy GetPolicyById(int id) => _context.Policies.Find(id);

        public List<Policy> GetAllPolicies() => _context.Policies.ToList();

        public bool UpdatePolicy(Policy policy)
        {
            _context.Policies.Update(policy);
            return _context.SaveChanges() > 0;
        }

        public bool DeletePolicy(int id)
        {
            var policy = _context.Policies.Find(id);
            if (policy == null) return false;
            _context.Policies.Remove(policy);
            return _context.SaveChanges() > 0;
        }
    }
}
