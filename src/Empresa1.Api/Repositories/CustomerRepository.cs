using Empresa1.Api.Data.Context;
using Empresa1.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Empresa1.Api.Repositories;

public class CustomerRepository(ApplicationDbContext applicationDbContext) : ICustomerRepository
{
    public IEnumerable<Customer?> GetAll()
    {
        return applicationDbContext.Customers.AsQueryable();
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid id)
    {
        return await applicationDbContext.Customers.AsQueryable()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Customer?>> GetCustomerByName(string name)
    {
        return await applicationDbContext.Customers
            .Where(c => EF.Functions.Like(c.Name, $"%{name}%"))
            .ToListAsync();
    }

    public async Task<Customer?> UpdateAsync(Customer customer, Guid id)
    {
        var existingCustomer = await GetCustomerByIdAsync(id);

        if (existingCustomer == null)
            return null;

        await ValidateEmailUniqueness(customer.Email, id);

        UpdateCustomerProperties(existingCustomer, customer);

        applicationDbContext.Customers.Update(existingCustomer);

        await applicationDbContext.SaveChangesAsync();

        return existingCustomer;
    }

    public async Task<Customer?> CreateAsync(Customer customer)
    {
        await ValidateEmailUniqueness(customer.Email);
        var customerEntity = await applicationDbContext.Customers.AddAsync(customer);
        await applicationDbContext.SaveChangesAsync();

        return customerEntity.Entity;
    }

    public async Task<Customer?> DeleteAsync(Guid id)
    {
        var customerEntity = await GetCustomerByIdAsync(id);

        if (customerEntity == null)
            return null;

        applicationDbContext.Customers.Remove(customerEntity);
        await applicationDbContext.SaveChangesAsync();
        return customerEntity;
    }

    public async Task<int> CountAsync()
    {
        return await applicationDbContext.Customers.AsQueryable().CountAsync();
    }

    private async Task ValidateEmailUniqueness(string customerEmail, Guid? id = null)
    {
        if (string.IsNullOrWhiteSpace(customerEmail))
            return;
        
        var query = applicationDbContext.Customers.AsQueryable();

        query = query.Where(c => c.Email == customerEmail);

        if (id.HasValue)
            query = query.Where(c => c.Id != id.Value);

        var emailExists = await query.AnyAsync();

        if (emailExists)
            throw new InvalidOperationException("Já existe outro cliente com o e-mail informado.");
    }

    private void UpdateCustomerProperties(Customer existingCustomer, Customer customer)
    {
        existingCustomer.Update(customer.Name, customer.Email, customer.Phone, customer.Address);
    }
}