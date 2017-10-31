using System.Data.Entity;
using Sennit.Domain.Entities;
using Sennit.Infra.Mappings;
using Sennit.Shared;

namespace Sennit.Infra.Contexts
{
    public class SennitDataContext : DbContext
    {
        public SennitDataContext() : base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }   
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CouponMap());
        }
    }
}