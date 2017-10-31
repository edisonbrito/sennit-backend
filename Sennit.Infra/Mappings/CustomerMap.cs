using System.Data.Entity.ModelConfiguration;
using Sennit.Domain.Entities;

namespace Sennit.Infra.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");
            HasKey(x => x.Id);
            Property(x => x.Cpf.Number).IsRequired().HasMaxLength(14).IsFixedLength();
            Property(x => x.Nome).IsRequired();          
            Property(x => x.Active).IsRequired();
            Property(x => x.Email.Address).IsRequired().HasMaxLength(160);        

            HasRequired(x => x.User);
        }
    }
}
