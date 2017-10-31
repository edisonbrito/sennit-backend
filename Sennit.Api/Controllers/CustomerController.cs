using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sennit.Domain.Commands.Handlers;
using Sennit.Domain.Commands.Inputs;
using Sennit.Domain.Repositories;
using Sennit.Infra.Transactions;

namespace Sennit.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerCommandHandler _handler;
        private readonly ICustomerRepository _customerRepository;


        public CustomerController(IUow uow
            , CustomerCommandHandler handler
            , ICustomerRepository custumerRepository         
            )
            : base(uow)
        {
            _customerRepository = custumerRepository;            
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/custumers/{idCustomer}/coupons")]
        [AllowAnonymous]
        public IActionResult GetCouponsById(int idCustomer)
        {
            return Ok("OI");
        }

        [Authorize("Admin")]
        [Route("v1/custumers")]        
        public IActionResult Get()
        {
            return Ok(_customerRepository.GetCustomers());
        }


        [HttpPost]
        [Route("v1/customers")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }
    }
}
