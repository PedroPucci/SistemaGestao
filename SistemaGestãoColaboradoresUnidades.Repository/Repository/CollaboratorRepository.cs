using Microsoft.EntityFrameworkCore;
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
            var response = _context.CollaboratorEntity.Update(collaboratorEntity);
            return response.Entity;
        }

        public async Task<CollaboratorEntity> AddCollaboratorAsync(CollaboratorEntity collaboratorEntity)
        {
            var result = await _context.CollaboratorEntity.AddAsync(collaboratorEntity);
            return result.Entity;
        }

        public async Task<CollaboratorEntity> DeleteCollaboratorAsync(string name)
        {
            var collaboratorToDelete = await _context.CollaboratorEntity.FirstOrDefaultAsync(collaborator => collaborator.Name == name);

            if (collaboratorToDelete != null)
            {
                _context.CollaboratorEntity.Remove(collaboratorToDelete);
                await _context.SaveChangesAsync();
            }

            return collaboratorToDelete;
        }

        public async Task<CollaboratorEntity> GetCollaboratorNameAsync(string? name)
        {
            return await _context.CollaboratorEntity.FirstOrDefaultAsync(collaborator => collaborator.Name == name);
        }

        public async Task<CollaboratorEntity> GetCollaboratorByIdAsync(int collaboratorId)
        {
            return await _context.CollaboratorEntity.FindAsync(collaboratorId);
        }
    }
}