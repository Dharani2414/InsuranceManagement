using DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InsuranceManagement 
{
    public class InsuranceDBFactory : IDesignTimeDbContextFactory<InsuranceDBContext>
    {
        public InsuranceDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InsuranceDBContext>();
            optionsBuilder.UseSqlServer("Server=LAPTOP-L4FV7ODF\\SQLEXPRESS01;Database=InsuranceDb;Trusted_Connection=True;Encrypt=False;");

            return new InsuranceDBContext(optionsBuilder.Options);
        }
    }
}
