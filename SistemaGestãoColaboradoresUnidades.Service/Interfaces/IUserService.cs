using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> AddUserEntity(UserEntityDto userEntityDto);
        Task<UserEntity> UpdateUserEntity(UserEntityDto userEntityDto);
    }
}