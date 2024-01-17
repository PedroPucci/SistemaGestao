using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }

        public Task<UserEntity> AddUserEntity(UserEntity userEntity)
        {
            throw new NotImplementedException();
        }

        public UserEntity UpdateUserEntity(UserEntity userEntity)
        {
            throw new NotImplementedException();
        }
    }
}