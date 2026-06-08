using ProductsApi.Core.Infrastructure.Domain.Models;

namespace ProductsApi.Core.Infrastructure.Db.Repos;

public interface IRepoBase<TModel> where TModel : ModelBase
{
    Task<IEnumerable<TModel>> FindAllAsync();
    Task<TModel?> FindByIdAsync(Guid id);
    
    Task AddAsync(TModel model);
    Task UpdateAsync(TModel model);
    
    Task RemoveByIdAsync(Guid id);
}