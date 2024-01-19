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

        public async Task<List<UnityEntity>> GetAllUnities()
        {
            throw new NotImplementedException();
        }

        public UnityEntity UpdateUnity(UnityEntity unityEntity)
        {
            var response = _context.UnityEntity.Update(unityEntity);
            return response.Entity;
        }
    }
}