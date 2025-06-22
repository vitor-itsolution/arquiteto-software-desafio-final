using Empresa1.Api.Models;

namespace Empresa1.Api.Repositories;

public interface ICustomerRepository
{
    IEnumerable<Customer?> GetAll();
    Task<Customer?> GetCustomerByIdAsync(Guid id);
    Task<IEnumerable<Customer?>> GetCustomerByName(string name);
    Task<Customer?> UpdateAsync(Customer customer, Guid id);
    Task<Customer?> CreateAsync(Customer customer);
    Task<Customer?> DeleteAsync(Guid id);
    Task<int> CountAsync();
}