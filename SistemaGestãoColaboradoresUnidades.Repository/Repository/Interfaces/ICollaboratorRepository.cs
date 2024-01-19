using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<List<CollaboratorEntity>> GetAllCollaborators();
        CollaboratorEntity UpdateCollaborator(CollaboratorEntity collaboratorEntity);
    }
}