

namespace MinimalApiTemplate.Application.Contracts;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync();
}
