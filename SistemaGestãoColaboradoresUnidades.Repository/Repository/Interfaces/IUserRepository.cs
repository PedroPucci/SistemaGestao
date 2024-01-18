using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserEntityAsync(UserEntity userEntity);
        UserEntity UpdateUserEntity(UserEntity userEntity);
        Task<List<UserEntity>> GetAllUserEntitiesAsync();
        Task<List<UserEntity>> GetAllUserEntityByStatusAsync(StatusUser statusUser);
    }
}