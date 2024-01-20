using Microsoft.EntityFrameworkCore;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository
{
    public class UnityRepository : IUnityRepository
    {
        private readonly DataBaseContext _context;

        public UnityRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<UnityEntity> AddUnityAsync(UnityEntity unityEntity)
        {
            var result = await _context.UnityEntity.AddAsync(unityEntity);
            return result.Entity;
        }

        public UnityEntity UpdateUnity(UnityEntity unityEntity)
        {
            var response = _context.UnityEntity.Update(unityEntity);
            return response.Entity;
        }

        public async Task<List<UnityEntity>> GetAllUnities()
        {
            throw new NotImplementedException();
        }

        public async Task<UnityEntity> GetUnityByCodeAsync(UnityEntity unityEntity)
        {
            return await _context.UnityEntity.Where(unity => unity.Code == unityEntity.Code).FirstAsync();
        }

        public async Task<UnityEntity> GetByIdAsync(int unityId)
        {
            return await _context.UnityEntity.FindAsync(unityId);
        }

        public async Task<int?> GetCodeAsync(int? code)
        {
            return await _context.UnityEntity
                .Where(unity => unity.Code == code)
                .Select(unity => (int?)unity.Code)
                .FirstOrDefaultAsync();
        }

        public async Task<int?> GetCodeAndIdAsync(int? id)
        {
            return await _context.UnityEntity
                .Where(unity => unity.Id == id)
                .Select(unity => (int?)unity.Code)
                .FirstOrDefaultAsync();
        }
    }
}