namespace SistemaGestãoColaboradoresUnidades.Service.Interfaces
{
    public interface IUnitOfWorkService
    {
        UserService UserService { get; }
        CollaboratorService CollaboratorService { get; }
        UnityService UnityService { get; }
    }
}