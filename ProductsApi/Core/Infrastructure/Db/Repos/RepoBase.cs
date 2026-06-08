using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Core.Infrastructure.Db.Entities;
using ProductsApi.Core.Infrastructure.Db.Mappers;
using ProductsApi.Core.Infrastructure.Domain.Models;

namespace ProductsApi.Core.Infrastructure.Db.Repos;

public abstract class RepoBase<TModel, TEntity>(
    DbContext ctx,
    DbSet<TEntity> set,
    IMapper<TModel, TEntity> mapper
) : IRepoBase<TModel>
    where TModel : ModelBase, new()
    where TEntity : EntityBase<TEntity>
{
    public async Task<IEnumerable<TModel>> FindAllAsync() =>
        await set
            .AsNoTracking()
            .Select(e => mapper.MapToModel(e))
            .ToArrayAsync();

    public async Task<TModel?> FindByIdAsync(Guid id)
    {
        var entity = await set.FindAsync(id);
        return entity == null ? null : mapper.MapToModel(entity);
    }

    public async Task AddAsync(TModel model)
    {
        var entity = mapper.MapToEntity(model);
        await set.AddAsync(entity);
        await ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(TModel model)
    {
        var entity = await set.FindAsync(model.Id) ?? throw new KeyNotFoundException();
        entity.Update(mapper.MapToEntity(model));
        await ctx.SaveChangesAsync();
    }

    public async Task RemoveByIdAsync(Guid id)
    {
        var entity = await set.FindAsync(id) ?? throw new KeyNotFoundException();
        set.Remove(entity);
        await ctx.SaveChangesAsync();
    }


    protected async Task<TModel?> FindByAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await set
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate);
        return entity == null ? null : mapper.MapToModel(entity);
    }

    protected async Task<IEnumerable<TModel>> FindAllByAsync(Expression<Func<TEntity, bool>> predicate) =>
        await set
            .AsNoTracking()
            .Where(predicate)
            .Select(e => mapper.MapToModel(e))
            .ToArrayAsync();

    protected async Task PartialUpdateByIdAsync(Guid id, Action<TEntity> partialUpdate)
    {
        var entity = await set.FindAsync(id) ?? throw new KeyNotFoundException();
        partialUpdate(entity);
        await ctx.SaveChangesAsync();
    }
}