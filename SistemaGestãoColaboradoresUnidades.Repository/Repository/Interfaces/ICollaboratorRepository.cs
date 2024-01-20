using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<List<CollaboratorEntity>> GetAllCollaborators();
        CollaboratorEntity UpdateCollaborator(CollaboratorEntity collaboratorEntity);
        Task<CollaboratorEntity> AddCollaboratorAsync(CollaboratorEntity collaboratorEntity);
        Task<CollaboratorEntity> DeleteCollaboratorAsync(string name);
        Task<CollaboratorEntity> GetCollaboratorNameAsync(string name);
    }
}