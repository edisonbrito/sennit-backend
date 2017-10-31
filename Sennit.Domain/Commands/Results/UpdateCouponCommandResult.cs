using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Results
{
    public class UpdateCouponCommandResult : ICommandResult
    {
        public UpdateCouponCommandResult(string number, string message, string awarded)
        {
            Number = number;
            Message = message;
            Awarded = awarded;
        }

        public string Message { get; set; }
        public string Number { get; set; }
        public string Awarded { get; set; }
    }
}
