using FluentValidator;

namespace Sennit.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email() { }
        public Email(string address)
        {
            Address = address;

            new ValidationContract<Email>(this)
                .IsEmail(x => x.Address, "E-mail inválido");
        }

        public string Address { get; private set; }
    }
}
