namespace Shared.Infrastructure;

public abstract class Mapper<TModel, TEntity>
    where TModel : Model, new()
    where TEntity : Entity, new()
{
    public virtual TModel MapToModel(TEntity entity) => new()
    {
        Id = entity.Id,
        CreatedAt = entity.CreatedAt,
        UpdatedAt = entity.UpdatedAt
    };

    public virtual TEntity MapToEntity(TModel model) => new()
    {
        Id = model.Id,
        CreatedAt = model.CreatedAt,
        UpdatedAt = model.UpdatedAt
    };
}