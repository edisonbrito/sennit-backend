using Sennit.Domain.Commands.Results;
using Sennit.Domain.Entities;
using System.Collections.Generic;

namespace Sennit.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(int id);
        Customer GetByUsername(string username);
        List<GetListCustomerCommandResult> GetCustomers();
        void Save(Customer customer);
        bool CpfExists(string document);
    }
}
