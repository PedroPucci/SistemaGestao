using AutoMapper;
using Microsoft.Extensions.Configuration;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Service.Service
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private UserService? userService;
        private UnityService? unityService;
        private CollaboratorService? collaboratorService;

        public UnitOfWorkService(IRepositoryUoW repositoryUoW, IMapper mapper, IConfiguration config)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
            _config = config;
        }

        public UserService UserService
        {
            get
            {
                if (userService == null)
                {
                    userService = new UserService(_repositoryUoW, _mapper);
                }
                return userService;
            }
        }

        public UnityService UnityService
        {
            get
            {
                if (unityService == null)
                {
                    unityService = new UnityService(_repositoryUoW, _mapper);
                }
                return unityService;
            }
        }

        public CollaboratorService CollaboratorService
        {
            get
            {
                if (collaboratorService == null)
                {
                    collaboratorService = new CollaboratorService(_repositoryUoW, _mapper);
                }
                return collaboratorService;
            }
        }
    }
}