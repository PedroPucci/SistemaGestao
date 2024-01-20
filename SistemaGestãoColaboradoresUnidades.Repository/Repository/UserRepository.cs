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

        public async Task<UserEntity> AddUserAsync(UserEntity userEntity)
        {
            var result = await _context.UserEntity.AddAsync(userEntity);
            return result.Entity;
        }

        public UserEntity UpdateUser(UserEntity userEntity)
        {
            var response = _context.UserEntity.Update(userEntity);
            return response.Entity;
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            return await _context.UserEntity.Select(user => new UserEntity
            {
                Login = user.Login,
                Status = user.Status
            }).ToListAsync();
        }

        public async Task<List<UserEntity>> GetAllUsersByStatusAsync(UserStatus userStatus)
        {
            return await _context.UserEntity.Where(user => user.Status == userStatus).Select(user => new UserEntity
            {
                Login = user.Login,
                Status = user.Status
            }).ToListAsync();
        }

        public async Task<UserEntity> GetUserByLoginAsync(UserEntity userEntity)
        {
            return await _context.UserEntity.Where(user => user.Login == userEntity.Login).FirstAsync();
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return await _context.UserEntity.FindAsync(userId);
        }
    }
}