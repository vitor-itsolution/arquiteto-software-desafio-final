using Empresa1.Api.Extensions;
using Empresa1.Api.Models;
using Empresa1.Api.Repositories;
using Empresa1.Api.ViewModels.Customers;

namespace Empresa1.Api.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public IEnumerable<CustomerViewModel> GetAll()
    {
        return customerRepository.GetAll()
            ?.Select(c => new CustomerViewModel(c.Id, c.Name, c.Email, c.Phone, c.Address, c.CreatedAt));
    }

    public async Task<CustomerViewModel?> GetCustomerByIdAsync(Guid id)
    {
        var customer = await customerRepository.GetCustomerByIdAsync(id);

        return customer == null
            ? null
            : new CustomerViewModel(customer.Id, customer.Name, customer.Email, customer.Phone, customer.Address,
                customer.CreatedAt);
    }

    public async Task<IEnumerable<CustomerViewModel?>> GetCustomerByName(string name)
    {
        var customers = await customerRepository.GetCustomerByName(name);

        if (customers == null || !customers.Any())
            return Enumerable.Empty<CustomerViewModel>();

        return customers.Select(c => new CustomerViewModel(c.Id, c.Name, c.Email, c.Phone, c.Address, c.CreatedAt));
    }

    public async Task<CustomerViewModel?> UpdateAsync(CustomerUpdateViewModel customer, Guid id)
    {
        var customerToUpdate =
            new Customer(customer.Name, customer.Email, customer.Phone?.OnlyNumbers(), customer.Address);
        var updatedCustomer = await customerRepository.UpdateAsync(customerToUpdate, id);

        return updatedCustomer == null
            ? null
            : new CustomerViewModel(updatedCustomer.Id, updatedCustomer.Name, updatedCustomer.Email,
                updatedCustomer.Phone, updatedCustomer.Address, updatedCustomer.CreatedAt);
    }

    public async Task<CustomerViewModel?> CreateAsync(CustomerCreateViewModel customer)
    {
        var customerToAdd =
            new Customer(customer.Name, customer.Email, customer.Phone?.OnlyNumbers(), customer.Address);
        var createdCustomer = await customerRepository.CreateAsync(customerToAdd);

        return createdCustomer == null
            ? null
            : new CustomerViewModel(createdCustomer.Id, createdCustomer.Name, createdCustomer.Email,
                createdCustomer.Phone, createdCustomer.Address, createdCustomer.CreatedAt);
    }

    public async Task<CustomerViewModel?> DeleteAsync(Guid id)
    {
        var deletedCustomer = await customerRepository.DeleteAsync(id);

        return deletedCustomer == null
            ? null
            : new CustomerViewModel(deletedCustomer.Id, deletedCustomer.Name, deletedCustomer.Email,
                deletedCustomer.Phone, deletedCustomer.Address,
                deletedCustomer.CreatedAt);
    }

    public async Task<CustomerTotalViewModel> CountAsync()
    {
        var total = await customerRepository.CountAsync();

        return new CustomerTotalViewModel(total);
    }
}