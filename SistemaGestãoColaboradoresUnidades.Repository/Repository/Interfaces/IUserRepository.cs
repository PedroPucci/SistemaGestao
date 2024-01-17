using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserEntity(UserEntity userEntity);
        UserEntity UpdateUserEntity(UserEntity userEntity);
    }
}