using Microsoft.EntityFrameworkCore.Storage;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository
{
    public class RepositoryUoW : IRepositoryUoW
    {
        private readonly DataBaseContext _context;
        private bool _disposed = false;
        private IUserRepository? _userRepository = null;
        private IUnityRepository? _unityRepository = null;
        private ICollaboratorRepository? _collaboratorRepository = null;

        public RepositoryUoW(DataBaseContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public IUnityRepository UnityRepository
        {
            get
            {
                if (_unityRepository == null)
                {
                    _unityRepository = new UnityRepository(_context);
                }
                return _unityRepository;
            }
        }

        public ICollaboratorRepository CollaboratorRepository
        {
            get
            {
                if (_collaboratorRepository == null)
                {
                    _collaboratorRepository = new CollaboratorRepository(_context);
                }
                return _collaboratorRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}