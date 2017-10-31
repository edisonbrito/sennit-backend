using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Results
{
    public class RegisterCouponCommandResult : ICommandResult
    {
        public RegisterCouponCommandResult(string number)
        {
            Numer = number;
        }

        public int Id { get; set; }
        public string Numer { get; set; }
    }
}
