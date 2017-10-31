using System;
using Sennit.Domain.ValueObjects;
using Sennit.Shared.Entities;

namespace Sennit.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer() { }

        public Customer(string nome, Email email, CPF cpf, User user)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            User = user;
            Active = true;

            AddNotifications(email.Notifications);
            AddNotifications(Cpf.Notifications);      
        }

        public string Nome { get; private set; }      
        public CPF Cpf { get; set; }      
        public Email Email { get; private set; }
        public bool Active { get; private set; }
        public User User { get; private set; }        
    }
}
