using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Domain.Validator;
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
        }

        public async Task<UnityEntity> AddUnity(UnityDto? unityDto)
        {
            await CheckValidParametersUnityAsync(unityDto);
            await CheckCodeUnityAsync(unityDto);

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                UnityEntity unityEntity = _mapper.Map<UnityDto, UnityEntity>(unityDto);
                unityEntity.Inactivated = false;

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
            finally
            {
                transaction.Dispose();
            }
        }

        private async Task CheckValidParametersUnityAsync(UnityDto? unityDto)
        {
            var unityValidation = await new UnityDtoValidator().ValidateAsync(unityDto);

            if (!unityValidation.IsValid)
                throw new InvalidOperationException("Invalid Parameters!");
        }

        private async Task CheckCodeUnityAsync(UnityDto? unityDto)
        {
            var unityCode = await _repositoryUoW.UnityRepository.GetCodeAsync(unityDto?.Code);

            if (unityDto?.Code == unityCode)
                throw new InvalidOperationException("The code exist, try other code!");
        }

        public async Task<List<UnityEntity>> GetAllUnities()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<UnityEntity> unityList = await _repositoryUoW.UnityRepository.GetAllUnities();
                _repositoryUoW.Commit();
                return unityList;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public async Task<UnityEntity> UpdateUnity(UnityDto unityDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                int codeUnity = (int)unityDto.Code;

                UnityEntity unityCode = await _repositoryUoW.UnityRepository.GetUnityByCodeAsync(codeUnity);

                if (unityCode == null)
                    throw new InvalidOperationException("Unity does not found!");

                unityCode.Inactivated = unityDto.Inactivated;
                unityCode.Name = unityDto.Name;
                unityCode.Inactivated = unityDto.Inactivated;

                var result = _repositoryUoW.UnityRepository.UpdateUnity(unityCode);

                await _repositoryUoW.SaveAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
            finally
            {
                transaction.Dispose();
            }
        }
    }
}