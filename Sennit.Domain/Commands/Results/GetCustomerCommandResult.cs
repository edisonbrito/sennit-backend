﻿using Sennit.Shared.Commands;

namespace Sennit.Domain.Commands.Results
{
    public class GetCustomerCommandResult : ICommandResult
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
