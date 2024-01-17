using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;

        public UserService(IRepositoryUoW repositoryUoW,
            IMapper mapper)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
            _mapper = mapper;
        }

        public Task<UserEntity> AddUserEntity(UserEntityDto userEntityDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> UpdateUserEntity(UserEntityDto userEntityDto)
        {
            throw new NotImplementedException();
        }
    }
}