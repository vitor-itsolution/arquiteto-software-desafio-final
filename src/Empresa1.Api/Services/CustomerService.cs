using Empresa1.Api.Extensions;
using Empresa1.Api.Models;
using Empresa1.Api.Repositories;
using Empresa1.Api.ViewModels.Base;
using Empresa1.Api.ViewModels.Customers;

namespace Empresa1.Api.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public OperationResult<IEnumerable<CustomerViewModel>> GetAll()
    {
        try
        {
            var customers = customerRepository.GetAll();

            if (customers == null || !customers.Any())
                return OperationResult<IEnumerable<CustomerViewModel>>.Ok(Enumerable.Empty<CustomerViewModel>());

            var result = customers.Select(c =>
                new CustomerViewModel(c.Id, c.Name, c.Email, c.Phone, c.Address, c.CreatedAt));

            return OperationResult<IEnumerable<CustomerViewModel>>.Ok(result);
        }
        catch (Exception ex)
        {
            return OperationResult<IEnumerable<CustomerViewModel>>.Fail("Erro ao recuperar clientes: " + ex.Message);
        }
    }


    public async Task<OperationResult<CustomerViewModel?>> GetCustomerByIdAsync(Guid id)
    {
        try
        {
            var customer = await customerRepository.GetCustomerByIdAsync(id);

            if (customer == null)
                return OperationResult<CustomerViewModel>.Fail("Cliente não encontrado.",
                    statusCode: StatusCodes.Status404NotFound);

            return OperationResult<CustomerViewModel>.Ok(new CustomerViewModel(customer.Id, customer.Name,
                customer.Email,
                customer.Phone, customer.Address,
                customer.CreatedAt));
        }
        catch (Exception ex)
        {
            return OperationResult<CustomerViewModel>.Fail("Erro ao recuperar clientes: " + ex.Message);
        }
    }

    public async Task<OperationResult<IEnumerable<CustomerViewModel?>>> GetCustomerByName(string name)
    {
        try
        {
            var customers = await customerRepository.GetCustomerByName(name);

            if (customers == null || !customers.Any())
                return OperationResult<IEnumerable<CustomerViewModel?>>.Fail("Cliente não encontrado.",
                    statusCode: StatusCodes.Status404NotFound);

            var customersViewModel = customers.Select(c =>
                new CustomerViewModel(c.Id, c.Name, c.Email, c.Phone, c.Address, c.CreatedAt));

            return OperationResult<IEnumerable<CustomerViewModel?>>.Ok(customersViewModel);
        }
        catch (Exception ex)
        {
            return OperationResult<IEnumerable<CustomerViewModel?>>.Fail("Erro ao recuperar clientes: " + ex.Message);
        }
    }

    public async Task<OperationResult<CustomerViewModel?>> UpdateAsync(CustomerUpdateViewModel customer, Guid id)
    {
        try
        {
            var customerToUpdate =
                new Customer(customer.Name, customer.Email, customer.Phone?.OnlyNumbers(), customer.Address);

            var updatedCustomer = await customerRepository.UpdateAsync(customerToUpdate, id);

            if (updatedCustomer == null)
                return OperationResult<CustomerViewModel?>.Fail("Cliente não encontrado.",
                    statusCode: StatusCodes.Status404NotFound);

            return OperationResult<CustomerViewModel?>.Ok(new CustomerViewModel(updatedCustomer.Id,
                updatedCustomer.Name,
                updatedCustomer.Email,
                updatedCustomer.Phone, updatedCustomer.Address, updatedCustomer.CreatedAt));
        }
        catch (Exception ex)
        {
            return OperationResult<CustomerViewModel?>.Fail($"Erro ao atualizar o cliente: {id} " +
                                                            ex.Message);
        }
    }

    public async Task<OperationResult<CustomerViewModel?>> CreateAsync(CustomerCreateViewModel customer)
    {
        try
        {
            var customerToAdd =
                new Customer(customer.Name, customer.Email, customer.Phone?.OnlyNumbers(), customer.Address);

            var createdCustomer = await customerRepository.CreateAsync(customerToAdd);

            return OperationResult<CustomerViewModel?>.Ok(new CustomerViewModel(createdCustomer.Id,
                createdCustomer.Name,
                createdCustomer.Email,
                createdCustomer.Phone, createdCustomer.Address, createdCustomer.CreatedAt));
        }
        catch (Exception ex)
        {
            return OperationResult<CustomerViewModel?>.Fail($"Erro ao tentar criar o cliente: " +
                                                            ex.Message);
        }
    }

    public async Task<OperationResult<CustomerViewModel?>> DeleteAsync(Guid id)
    {
        try
        {
            var deletedCustomer = await customerRepository.DeleteAsync(id);

            if (deletedCustomer == null)
                return OperationResult<CustomerViewModel?>.Fail("Cliente não encontrado.",
                    statusCode: StatusCodes.Status404NotFound);

            return OperationResult<CustomerViewModel?>.Ok(new CustomerViewModel(deletedCustomer.Id,
                deletedCustomer.Name,
                deletedCustomer.Email,
                deletedCustomer.Phone, deletedCustomer.Address,
                deletedCustomer.CreatedAt));
        }
        catch (Exception ex)
        {
            return OperationResult<CustomerViewModel?>.Fail($"Erro ao tentar deletar o cliente: " +
                                                            ex.Message);
        }
    }

    public async Task<OperationResult<CustomerTotalViewModel>> CountAsync()
    {
        try
        {
            var total = await customerRepository.CountAsync();

            return OperationResult<CustomerTotalViewModel>.Ok(new CustomerTotalViewModel(total));
        }
        catch (Exception ex)
        {
            return OperationResult<CustomerTotalViewModel?>.Fail($"Erro ao tentar obter a quantidade total de clientes: " +
                                                                 ex.Message);
        }
    }
}