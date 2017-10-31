using Sennit.Domain.Commands.Inputs;
using Sennit.Domain.Commands.Results;
using Sennit.Domain.Entities;
using System.Collections.Generic;

namespace Sennit.Domain.Repositories
{
    public interface ICouponRepository
    {
        List<GetListCouponCommandResult> GetList(bool isAwarded, int skip, int take);
        List<Coupon> GetListOrderByCustomer(int idCustomer);
        Coupon Get(string number);
        bool CouponExists(string number);
        bool IsUsed(string numbem);
        int QuantityByUsers(int idCustomer);
        bool IsAwarded(string number);      
        void Save(Coupon coupon);
        void update(Coupon coupon);
    }
}
