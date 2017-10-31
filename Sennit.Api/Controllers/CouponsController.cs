using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sennit.Domain.Commands.Handlers;
using Sennit.Domain.Commands.Inputs;
using Sennit.Domain.Repositories;
using Sennit.Infra.Transactions;

namespace Sennit.Api.Controllers
{
    public class CouponsController : BaseController
    {
        private readonly CouponCommandHandler _handler;
        private readonly CouponUpdateCommandHandler _handlerUpdate;
        private readonly ICouponRepository _couponRepository;

        public CouponsController(IUow uow
            , CouponCommandHandler handler
            , CouponUpdateCommandHandler handlerUpdate
            , ICouponRepository couponRepository
            )
            : base(uow)
        {
            _couponRepository = couponRepository;
            _handler = handler;
            _handlerUpdate = handlerUpdate;
        }


        [HttpGet]
        [Route("v1/couponsAwarded")]
        [AllowAnonymous]
        public IActionResult GetAwarded()
        {
            return Ok(_couponRepository.GetList(true,10,5));
        }

        [HttpGet]
        [Route("v1/couponsNotAwarded")]
        [AllowAnonymous]
        public IActionResult GetNotAwarded()
        {
            return Ok(_couponRepository.GetList(false, 10, 5));
        }

        [HttpGet]
        [Route("v1/couponsByCustomer/{idCustomer}")]
        [AllowAnonymous]
        public IActionResult GetCouponsByCustomer(int idCustomer)
        {
            return Ok(_couponRepository.GetListOrderByCustomer(idCustomer));
        }
        
        [HttpPost]
        [Route("v1/coupon")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterCouponCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPatch]
        [Route("v1/couponUpdateByCustomer/")]
        [AllowAnonymous]
        public async Task<IActionResult> Put([FromBody] UpdateCouponCommand command)
        {
            var result = _handlerUpdate.Handle(command);
            return await Response(result, _handlerUpdate.Notifications);
        }
    }
}
