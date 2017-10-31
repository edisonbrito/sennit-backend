using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Sennit.Domain.Commands.Results;
using Sennit.Domain.Entities;
using Sennit.Domain.Repositories;
using Sennit.Infra.Contexts;

namespace Sennit.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SennitDataContext _context;

        public CustomerRepository(SennitDataContext context)
        {
            _context = context;
        }

        public Customer Get(int id)
        {
            return _context
                .Customers
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public Customer GetByUsername(string username)
        {
            return _context
                .Customers
                .Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefault(x => x.User.Username == username);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public bool CpfExists(string document)
        {
            return _context.Customers.Any(x => x.Cpf.Number == document);
        }

        public List<GetListCustomerCommandResult> GetCustomers()
        {
            return _context
                    .Customers
                    .Select(x => new GetListCustomerCommandResult
                    {
                        Name = x.Nome,
                        Cpf = x.Cpf.Number,
                        Email = x.Email.Address
                    })
                    .ToList();
        }
    }
}
