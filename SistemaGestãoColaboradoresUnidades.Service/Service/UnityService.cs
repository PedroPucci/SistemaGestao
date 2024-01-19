using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Service.Service
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

        public async Task<UnityEntity> AddUnity(UnityDto unityDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                UnityEntity unityEntity = _mapper.Map<UnityDto, UnityEntity>(unityDto);
                var result = await _repositoryUoW.UnityRepository.AddUnityAsync(unityEntity);

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

        public Task<List<UnityEntity>> GetAllUnities()
        {
            throw new NotImplementedException();
        }

        public Task<UnityEntity> UpdateUnity(UnityDto unityDto)
        {
            throw new NotImplementedException();
        }
    }
}