using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain;

namespace SistemaGestãoColaboradoresUnidades.Service.Interfaces
{
    public interface ICollaboratorService
    {
        Task<CollaboratorEntity> UpdateUnityEntity(UnityEntityDto unityEntityDto);
        Task<List<CollaboratorEntity>> GetAllUnityEntites();
    }
}