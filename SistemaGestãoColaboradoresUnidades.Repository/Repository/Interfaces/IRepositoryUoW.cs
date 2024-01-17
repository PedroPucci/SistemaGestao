using Microsoft.EntityFrameworkCore.Storage;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface IRepositoryUoW
    {
        IUserRepository UserRepository { get; }
        IUnityRepository UnityRepository { get; }
        ICollaboratorRepository CollaboratorRepository { get; }

        Task SaveAsync();
        void Commit();
        IDbContextTransaction BeginTransaction();
    }
}