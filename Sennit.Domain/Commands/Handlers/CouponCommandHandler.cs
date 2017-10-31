using FluentValidator;
using Sennit.Domain.Commands.Inputs;
using Sennit.Domain.Commands.Results;
using Sennit.Domain.Entities;
using Sennit.Domain.Repositories;
using Sennit.Domain.ValueObjects;
using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Handlers
{
    public class CouponCommandHandler : Notifiable,
        ICommandHandler<RegisterCouponCommand>
    {
        private readonly ICouponRepository _couponRepository;

        public CouponCommandHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public ICommandResult Handle(RegisterCouponCommand command)
        {
            if (_couponRepository.CouponExists(command.Number))
            {
                AddNotification("Cupom", "Este cupom já está registrado!");
                return null;
            }
            
            var coupom = new Coupon(null, command.Number, command.Isawarded);
       
            if (!IsValid())
                return null;

            _couponRepository.Save(coupom);

            return new RegisterCouponCommandResult(coupom.Number);
        } 
    }
}
