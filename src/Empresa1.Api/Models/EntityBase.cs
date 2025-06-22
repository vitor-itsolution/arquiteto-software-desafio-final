namespace Empresa1.Api.Models;

public class EntityBase
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}