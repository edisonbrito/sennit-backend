using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Results
{
    public class GetListCouponCommandResult : ICommandResult
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsAwarded { get; set; }     
        public bool IsUsed { get; set; }
    }
}
