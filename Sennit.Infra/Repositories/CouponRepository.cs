using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Sennit.Domain.Commands.Inputs;
using Sennit.Domain.Commands.Results;
using Sennit.Domain.Entities;
using Sennit.Domain.Repositories;
using Sennit.Infra.Contexts;

namespace Sennit.Infra.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly SennitDataContext _context;

        public CouponRepository() { }

        public CouponRepository(SennitDataContext context)
        {
            _context = context;
        }

        public bool CouponExists(string number)
        {
            return _context.Coupons.Any(x => x.Number == number);
        }

        public bool IsUsed(string number)
        {
            return _context.Coupons.Any(x => x.Number == number && x.IsUsed == true);
        }

        public List<GetListCouponCommandResult> GetList(bool isAwarded, int skip, int take)
        {
            return _context
                   .Coupons
                   .Select(x => new GetListCouponCommandResult
                   {
                       Id = x.Id,
                       Number = x.Number,
                       IsAwarded = x.Isawarded,
                       IsUsed = x.IsUsed

                   })
                   .Where(x => x.IsAwarded == isAwarded)
                   .Skip(skip)
                   .Take(take)
                   .ToList();
        }

        public List<Coupon> GetListOrderByCustomer(int idCustomer)
        {
            return _context.Coupons.Where(x => x.IdCustomer == idCustomer).ToList();
        }

        public bool IsAwarded(string number)
        {
            return _context.Coupons.Any(x => x.Number == number && x.Isawarded == true);
        }

        public void Save(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
        }

        public void update(Coupon coupon)
        {
            _context.Entry(coupon).State = EntityState.Modified;
        }

        public Coupon Get(string number)
        {
            return _context.Coupons.FirstOrDefault(x => x.Number == number);
        }

        public int QuantityByUsers(int idCustomer)
        {
            return _context.Coupons.Count(x => x.IdCustomer == idCustomer);
        }
    }
}
