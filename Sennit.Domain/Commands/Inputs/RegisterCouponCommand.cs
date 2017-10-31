using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Inputs
{
    public class RegisterCouponCommand : ICommand
    {
        public string Number { get; private set; }
        public bool Isawarded { get; private set; }
    }
}
