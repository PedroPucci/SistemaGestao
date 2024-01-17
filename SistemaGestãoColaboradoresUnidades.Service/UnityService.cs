using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Service
{
    public class UnityService : IUnityService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;

        public UnityService(IRepositoryUoW repositoryUoW,
            IMapper mapper)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
            _mapper = mapper;
        }

        public Task<List<UnityEntity>> GetAllUnityEntites()
        {
            throw new NotImplementedException();
        }

        public Task<UnityEntity> UpdateUnityEntity(UnityEntityDto unityEntityDto)
        {
            throw new NotImplementedException();
        }
    }
}