using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
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

        public async Task<UnityEntity> AddUnityEntity(UnityEntityDto unityEntityDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                UnityEntity unityEntity = _mapper.Map<UnityEntityDto, UnityEntity>(unityEntityDto);
                var result = await _repositoryUoW.UnityRepository.AddUnityEntityAsync(unityEntity);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
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