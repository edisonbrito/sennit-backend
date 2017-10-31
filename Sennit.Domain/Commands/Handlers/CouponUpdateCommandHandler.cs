using FluentValidator;
using Sennit.Domain.Commands.Inputs;
using Sennit.Domain.Commands.Results;
using Sennit.Domain.Entities;
using Sennit.Domain.Repositories;
using Sennit.Domain.ValueObjects;
using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Handlers
{
    public class CouponUpdateCommandHandler : Notifiable,
        ICommandHandler<UpdateCouponCommand>
    {
        private readonly ICouponRepository _couponRepository;

        public CouponUpdateCommandHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public ICommandResult Handle(UpdateCouponCommand command)
        {
            if (!_couponRepository.CouponExists(command.Number))
            {
                AddNotification("Cupom", "Este cupom não existe, verifique se digitou de forma correta.");
                return null;
            }

            if (_couponRepository.IsUsed(command.Number))
            {
                AddNotification("Cupom", "Este cupom já foi registrado! por outro participante");
                return null;
            }

            if (_couponRepository.QuantityByUsers(command.IdCustomer) > 5)
            {
                AddNotification("Cupom", "Cada participante só pode cadastrar 5 cupons.");
                return null;
            }
            

            var coupon = _couponRepository.Get(command.Number);
            coupon.UpdateCoupon(command.IdCustomer);

            if (!IsValid())
                return null;

            _couponRepository.update(coupon);

            return new UpdateCouponCommandResult(coupon.Number, " Parabéns você acabou de registrar seu cupom. ", coupon.ConfirmeIsIsawarded());
        }
    }
}
