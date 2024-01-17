using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Service.Interfaces
{
    public interface ICollaboratorService
    {
        Task<CollaboratorEntity> UpdateUnityEntity(UnityEntityDto unityEntityDto);
        Task<List<CollaboratorEntity>> GetAllUnityEntites();
    }
}