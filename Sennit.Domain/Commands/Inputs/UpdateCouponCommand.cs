using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Inputs
{
    public class UpdateCouponCommand : ICommand
    {
        public string Number { get; set; }
        public int IdCustomer { get; set; }      
    }
}

