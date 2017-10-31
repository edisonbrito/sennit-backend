using FluentValidator;
using Sennit.Domain.Commands.Inputs;
using Sennit.Domain.Commands.Results;
using Sennit.Domain.Entities;
using Sennit.Domain.Repositories;
using Sennit.Domain.ValueObjects;
using Sennit.Shared.Commands;


namespace Sennit.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notifiable,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            if (_customerRepository.CpfExists(command.Cpf))
            {
                AddNotification("Cpf", "Este Cpf já está em uso!");
                return null;
            }

            var cpf = new CPF(command.Cpf);
            var email = new Email(command.Email);
            var user = new User(command.Username, command.Password);
            var customer = new Customer(command.Nome, email, cpf, user);

            AddNotifications(cpf.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            if (!IsValid())
                return null;

            _customerRepository.Save(customer);

            return new RegisterCustomerCommandResult(customer.Id, "teste");
        }
    }
}
