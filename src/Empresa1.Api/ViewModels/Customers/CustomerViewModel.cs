namespace Empresa1.Api.ViewModels.Customers;

public record CustomerViewModel(Guid Id, string Name, string Email, string? Phone, string? Address, DateTime CreatedAt);
public record CustomerTotalViewModel(int Total);