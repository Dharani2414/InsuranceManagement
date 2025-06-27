using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;
namespace DAO
{
    public class InsuranceDBContext : DbContext
    {
        public InsuranceDBContext(DbContextOptions<InsuranceDBContext> options)
           : base(options) { }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Policy)
                .WithMany(p => p.Claims)
                .HasForeignKey(c => c.PolicyId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Client)
                .WithMany(cl => cl.Claims)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);  

            
            modelBuilder.Entity<PaymentDetails>()
                .HasOne(p => p.Client)
                .WithMany(c => c.PaymentDetails)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);  

            
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Policy)
                .WithMany(p => p.Clients)
                .HasForeignKey(c => c.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);  
        }

    }
}
