using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces
{
    public interface ICollaboratorService
    {
        Task<CollaboratorEntity> AddCollaborator(CollaboratorDto collaboratorDto);
        Task<CollaboratorEntity> DeleteCollaborator(string name);
        Task<CollaboratorEntity> UpdateCollaborator(CollaboratorDto collaboratorEntityDto);
        Task<List<CollaboratorEntity>> GetAllCollaborators();
    }
}