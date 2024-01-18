using Microsoft.EntityFrameworkCore;
using SistemaGestãoColaboradoresUnidades.Domain.Constant;
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

        public async Task<UserEntity> AddUserEntityAsync(UserEntity userEntity)
        {
            var result = await _context.UserEntity.AddAsync(userEntity);
            return result.Entity;
        }

        public UserEntity UpdateUserEntity(UserEntity userEntity)
        {
            var response = _context.UserEntity.Update(userEntity);
            return response.Entity;
        }

        public async Task<List<UserEntity>> GetAllUserEntitiesAsync()
        {
            return await _context.UserEntity.ToListAsync();
        }

        public async Task<List<UserEntity>> GetAllUserEntityByStatusAsync(StatusUser statusUser)
        {
            return await _context.UserEntity.Where(user => user.StatusUser == statusUser).ToListAsync();
        }

        //public async Task<List<UserEntity>> GetUserEntityAsync(UserEntity userEntity)
        //{
        //    return await _context.UserEntity.Where(user => user.StatusUser == statusUser).ToListAsync();
        //}
    }
}