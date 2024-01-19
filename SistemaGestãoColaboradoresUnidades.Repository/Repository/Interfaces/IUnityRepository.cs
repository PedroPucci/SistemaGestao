using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface IUnityRepository
    {
        Task<UnityEntity> AddUnityAsync(UnityEntity unityEntity);
        Task<List<UnityEntity>> GetAllUnities();
        Task<UnityEntity> GetUnityByCodeAsync(UnityEntity unityEntity);
        UnityEntity UpdateUnity(UnityEntity unityEntity);
        Task<int?> GetCodeAsync(int? code);
    }
}