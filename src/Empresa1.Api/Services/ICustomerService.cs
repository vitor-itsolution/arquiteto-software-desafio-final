using Empresa1.Api.Models;
using Empresa1.Api.ViewModels.Base;
using Empresa1.Api.ViewModels.Customers;

namespace Empresa1.Api.Services;

public interface ICustomerService
{
    public OperationResult<IEnumerable<CustomerViewModel>> GetAll();

    public Task<OperationResult<CustomerViewModel?>> GetCustomerByIdAsync(Guid id);
    public Task<OperationResult<IEnumerable<CustomerViewModel?>>> GetCustomerByName(string name);
    public Task<OperationResult<CustomerViewModel?>> UpdateAsync(CustomerUpdateViewModel customer, Guid id);
    public Task<OperationResult<CustomerViewModel?>> CreateAsync(CustomerCreateViewModel customer);
    public Task<OperationResult<CustomerViewModel?>> DeleteAsync(Guid id);
    public Task<OperationResult<CustomerTotalViewModel>> CountAsync();
}