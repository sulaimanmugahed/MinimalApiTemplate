using MinimalApiTemplate.Domain.Common;


namespace MinimalApiTemplate.Application.Contracts.Persistence;
public interface IGenericRepository<TEntity,TId> where TEntity : BaseEntity 
{
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(TId id);
    Task<TEntity> AddAsync(TEntity entity);
    TEntity Delete(TEntity entity);

}
