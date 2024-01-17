using SistemaGestãoColaboradoresUnidades.Domain;
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

        public Task<List<UnityEntity>> GetAllUnityEntites()
        {
            throw new NotImplementedException();
        }

        public UnityEntity UpdateUnityEntity(UnityEntity unityEntity)
        {
            throw new NotImplementedException();
        }
    }
}