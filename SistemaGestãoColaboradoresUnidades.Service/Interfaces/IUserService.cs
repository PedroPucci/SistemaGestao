using SistemaGestãoColaboradoresUnidades.Domain;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;

namespace SistemaGestãoColaboradoresUnidades.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> AddUserEntity(UserEntityDto userEntityDto);
        Task<UserEntity> UpdateUserEntity(UserEntityDto userEntityDto);
    }
}