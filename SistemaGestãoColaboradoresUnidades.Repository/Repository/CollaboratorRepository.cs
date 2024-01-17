using SistemaGestãoColaboradoresUnidades.Domain;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly DataBaseContext _context;

        public CollaboratorRepository(DataBaseContext context)
        {
            _context = context;
        }

        public Task<List<CollaboratorEntity>> GetAllCollaboratorEntites()
        {
            throw new NotImplementedException();
        }

        public CollaboratorEntity UpdateCollaboratorEntity(CollaboratorEntity collaboratorEntity)
        {
            throw new NotImplementedException();
        }
    }
}