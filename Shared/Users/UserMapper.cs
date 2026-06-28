using Shared.Infrastructure;

namespace Shared.Users;

public sealed class UserMapper : Mapper<UserModel, UserEntity>
{
    public override UserModel MapToModel(UserEntity entity)
    {
        return base.MapToModel(entity) with
        {
            Name = entity.Name,
            Balance = entity.Balance,
            PasswordHash = entity.PasswordHash,
            Phone = entity.Phone,
            Role = entity.Role
        };
    }

    public override UserEntity MapToEntity(UserModel model)
    {
        var entity = base.MapToEntity(model);
        entity.Name = model.Name;
        entity.Balance = model.Balance;
        entity.PasswordHash = model.PasswordHash;
        entity.Phone = model.Phone;
        entity.Role = model.Role;
        return entity;
    }
}