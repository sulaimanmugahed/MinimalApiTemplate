using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MinimalApiTemplate.Application.Contracts.Persistence;
using MinimalApiTemplate.Domain.Common;
using MinimalApiTemplate.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApiTemplate.Persistence.Repositories;

public class GenericRepository<TEntity, TId>(ApplicationDbContext context) 
    : IGenericRepository<TEntity, TId>
    where TEntity : BaseEntity 
   
{
    public async Task<TEntity> AddAsync(TEntity entity)
    {
       await context.Set<TEntity>()
            .AddAsync(entity);
       return entity;
    }

    public TEntity Delete(TEntity entity)
    {
         context.Set<TEntity>()
            .Remove(entity);
        return entity;
    }


    public async Task<IReadOnlyList<TEntity>> GetAllAsync() 
        => await context.Set<TEntity>()
            .ToListAsync();

    public async Task<TEntity> GetByIdAsync(TId id)
        => await context.Set<TEntity>()
             .FindAsync(id);
}
