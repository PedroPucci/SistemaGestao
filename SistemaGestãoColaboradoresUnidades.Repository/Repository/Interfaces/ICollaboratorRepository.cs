using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface ICollaboratorRepository
    {
        CollaboratorEntity UpdateCollaborator(CollaboratorEntity collaboratorEntity);
        Task<CollaboratorEntity> AddCollaboratorAsync(CollaboratorEntity collaboratorEntity);
        Task<CollaboratorEntity> DeleteCollaboratorAsync(string name);
        Task<CollaboratorEntity> GetCollaboratorNameAsync(string name);
        Task<CollaboratorEntity> GetCollaboratorByIdAsync(int collaboratorId);
        Task<List<CollaboratorEntity>> GetAllCollaborators();
    }
}