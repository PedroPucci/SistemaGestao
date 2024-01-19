using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface IUnityRepository
    {
        Task<UnityEntity> AddUnityEntityAsync(UnityEntity unityEntity);
        Task<List<UnityEntity>> GetAllUnityEntites();
        UnityEntity UpdateUnityEntity(UnityEntity unityEntity);
    }
}
