using SistemaGestãoColaboradoresUnidades.Service.Service;

namespace SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces
{
    public interface IUnitOfWorkService
    {
        UserService UserService { get; }
        CollaboratorService CollaboratorService { get; }
        UnityService UnityService { get; }
    }
}