using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sennit.Domain.Entities;


namespace Sennit.Infra.Mappings 
{
    public class CouponMap : EntityTypeConfiguration<Coupon>
    {
        public CouponMap()
        {
            ToTable("Coupon");
            HasKey(x => x.Id);
            Property(x => x.Number).IsRequired();
            Property(x => x.IsUsed).IsRequired();            
            Property(x => x.Isawarded).IsRequired();
            Property(x => x.IdCustomer);
        }
    }
}
