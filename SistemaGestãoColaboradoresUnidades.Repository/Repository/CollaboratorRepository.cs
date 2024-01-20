using SistemaGestãoColaboradoresUnidades.Domain.Entity;
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

        public Task<List<CollaboratorEntity>> GetAllCollaborators()
        {
            throw new NotImplementedException();
        }

        public CollaboratorEntity UpdateCollaborator(CollaboratorEntity collaboratorEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<CollaboratorEntity> AddCollaboratorAsync(CollaboratorEntity collaboratorEntity)
        {
            var result = await _context.CollaboratorEntity.AddAsync(collaboratorEntity);
            return result.Entity;
        }

        public async Task<CollaboratorEntity> DeleteCollaboratorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CollaboratorEntity> GetCollaboratorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}