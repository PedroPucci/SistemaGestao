using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> AddUser(UserDto userDto);
        Task<UserEntity> UpdateUser(UserDto userDto);
        Task<List<UserEntity>> GetAllUsers();
        Task<List<UserEntity>> GetAllUsersByStatus(UserStatus statusUser);
    }
}