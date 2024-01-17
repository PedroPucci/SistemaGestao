using SistemaGestãoColaboradoresUnidades.Domain;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface ICollaboratorRepository
    {
        Task<List<CollaboratorEntity>> GetAllCollaboratorEntites();
        CollaboratorEntity UpdateCollaboratorEntity(CollaboratorEntity collaboratorEntity);
    }
}