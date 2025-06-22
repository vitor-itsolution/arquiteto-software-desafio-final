using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa1.Api.Models;

public class Customer(string name, string email, string? phone, string? address)
    : EntityBase
{
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public string? Phone { get; private set; } = phone;
    public string? Address { get; private set; } = address;

    public void Update(string name, string email, string? phone, string? address)
    {
        SetName(name);
        SetEmail(email);
        SetPhone(phone);
        SetAddress(address);
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome do cliente é obrigatório.", nameof(name));

        Name = name.Trim();
    }

    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("E-mail é obrigatório.", nameof(email));

        Email = email.Trim().ToLowerInvariant();
    }

    private void SetPhone(string? phone)
    {
        Phone = string.IsNullOrWhiteSpace(phone) ? null : phone.Trim();
    }

    private void SetAddress(string? address)
    {
        Address = string.IsNullOrWhiteSpace(address) ? null : address.Trim();
    }
}
