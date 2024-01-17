using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Service
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly IRepositoryUoW _repositoryUoW;
        private readonly IMapper _mapper;

        public CollaboratorService(IRepositoryUoW repositoryUoW,
            IMapper mapper)
        {
            _repositoryUoW = repositoryUoW;
            _mapper = mapper;
            _mapper = mapper;
        }

        public Task<List<CollaboratorEntity>> GetAllUnityEntites()
        {
            throw new NotImplementedException();
        }

        public Task<CollaboratorEntity> UpdateUnityEntity(UnityEntityDto unityEntityDto)
        {
            throw new NotImplementedException();
        }
    }
}