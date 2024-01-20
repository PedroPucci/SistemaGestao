using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface IUnityRepository
    {
        Task<UnityEntity> AddUnityAsync(UnityEntity unityEntity);
        Task<List<UnityEntity>> GetAllUnities();
        UnityEntity UpdateUnity(UnityEntity unityEntity);
        Task<int?> GetCodeAsync(int? code);
        Task<int?> GetCodeAndIdAsync(int? id);
        Task<UnityEntity> GetByIdAsync(int unityId);
        Task<UnityEntity> GetUnityByCodeAsync(int code);
    }
}