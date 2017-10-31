using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Inputs
{
    public class AuthenticateUserCommand : ICommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
