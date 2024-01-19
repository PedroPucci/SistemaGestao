using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces
{
    public interface IUnityService
    {
        Task<UnityEntity> UpdateUnity(UnityDto unityDto);
        Task<List<UnityEntity>> GetAllUnities();
        Task<UnityEntity> AddUnity(UnityDto unityDto);
    }
}