using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserEntity> AddUserEntity(UserEntityDto userEntityDto);
        Task<UserEntity> UpdateUserEntity(UserEntityDto userEntityDto);
        Task<List<UserEntity>> GetAllUserEntities();
        Task<List<UserEntity>> GetAllUserEntityByStatus(StatusUser statusUser);
    }
}