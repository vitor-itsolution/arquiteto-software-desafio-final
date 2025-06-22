using Empresa1.Api.Models;
using Empresa1.Api.ViewModels.Customers;

namespace Empresa1.Api.Services;

public interface ICustomerService
{
    public IEnumerable<CustomerViewModel?> GetAll();

    public Task<CustomerViewModel?> GetCustomerByIdAsync(Guid id);
    public Task<IEnumerable<CustomerViewModel?>> GetCustomerByName(string name);
    public Task<CustomerViewModel?> UpdateAsync(CustomerUpdateViewModel customer, Guid id);
    public Task<CustomerViewModel?> CreateAsync(CustomerCreateViewModel customer);
    public Task<CustomerViewModel?> DeleteAsync(Guid id);
    public Task<CustomerTotalViewModel> CountAsync();
}