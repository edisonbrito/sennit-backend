using Sennit.Infra.Contexts;

namespace Sennit.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly SennitDataContext _context;

        public Uow(SennitDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {  
        }
    }
}
