using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<List<CollaboratorEntity>> GetAllCollaborators();
        CollaboratorEntity UpdateCollaborator(CollaboratorEntity collaboratorEntity);
        Task<CollaboratorEntity> AddCollaboratorAsync(CollaboratorEntity collaboratorEntity);
        Task<CollaboratorEntity> DeleteCollaboratorAsync(int id);
        Task<CollaboratorEntity> GetCollaboratorByIdAsync(int id);
    }
}