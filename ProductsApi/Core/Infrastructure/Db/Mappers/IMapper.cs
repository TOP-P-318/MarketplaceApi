using ProductsApi.Core.Infrastructure.Db.Entities;
using ProductsApi.Core.Infrastructure.Domain.Models;

namespace ProductsApi.Core.Infrastructure.Db.Mappers;

public interface IMapper<TModel, TEntity>
    where TModel : ModelBase
    where TEntity : EntityBase
{
    TModel MapToModel(TEntity entity);
    TEntity MapToEntity(TModel model);
}