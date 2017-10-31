using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Inputs
{
    public class RegisterCustomerCommand : ICommand
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }     
    }
}
