using SistemaGestãoColaboradoresUnidades.Domain;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;

namespace SistemaGestãoColaboradoresUnidades.Service.Interfaces
{
    public interface IUnityService
    {
        Task<UnityEntity> UpdateUnityEntity(UnityEntityDto unityEntityDto);
        Task<List<UnityEntity>> GetAllUnityEntites();
    }
}