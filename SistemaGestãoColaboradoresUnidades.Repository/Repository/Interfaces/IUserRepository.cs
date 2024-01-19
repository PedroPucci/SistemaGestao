using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserAsync(UserEntity userEntity);
        UserEntity UpdateUser(UserEntity userEntity);
        Task<List<UserEntity>> GetAllUsersAsync();
        Task<List<UserEntity>> GetAllUsersByStatusAsync(UserStatus userStatus);
        Task<UserEntity> GetUserByLoginAsync(UserEntity userEntity);
    }
}