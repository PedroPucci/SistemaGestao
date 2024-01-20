using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Domain.Validator;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Service.Service
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
        }

        public Task<List<CollaboratorEntity>> GetAllCollaborators()
        {
            throw new NotImplementedException();
        }

        public Task<CollaboratorEntity> UpdateCollaborator(CollaboratorDto collaboratorDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CollaboratorEntity> AddCollaborator(CollaboratorDto collaboratorDto)
        {
            await CheckValidParametersCollaboratorAsync(collaboratorDto);
            await EnsureUnityExistsAsync(collaboratorDto);
            await EnsureUserExistsAsync(collaboratorDto);

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var collaboratorEntity = _mapper.Map<CollaboratorDto, CollaboratorEntity>(collaboratorDto);
                var unityEntity = await _repositoryUoW.UnityRepository.GetByIdAsync(collaboratorDto.UnityEntityId);
                var userEntity = await _repositoryUoW.UserRepository.GetUserByIdAsync(collaboratorDto.UserEntityId);
                                
                collaboratorEntity.UnityEntity = unityEntity;
                collaboratorEntity.UserEntity = userEntity;

                var result = await _repositoryUoW.CollaboratorRepository.AddCollaboratorAsync(collaboratorEntity);

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

        public async Task<CollaboratorEntity> DeleteCollaborator(string name)
        {
            var collaborator = await _repositoryUoW.CollaboratorRepository.GetCollaboratorNameAsync(name);

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var result = await _repositoryUoW.CollaboratorRepository.DeleteCollaboratorAsync(name);
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

        private async Task CheckValidParametersCollaboratorAsync(CollaboratorDto collaboratorDto)
        {
            var collaboratorValidation = await new CollaboratorDtoValidator().ValidateAsync(collaboratorDto);

            if (!collaboratorValidation.IsValid)
                throw new InvalidOperationException("Invalid Parameters!");
        }

        private async Task EnsureUnityExistsAsync(CollaboratorDto collaboratorDto)
        {
            var idUnity = await _repositoryUoW.UnityRepository.GetCodeAndIdAsync(collaboratorDto.UnityEntityId);
            
            if (idUnity == null)
                throw new InvalidOperationException("Unit does not exist!");
        }

        private async Task EnsureUserExistsAsync(CollaboratorDto collaboratorDto)
        {
            var idUser = await _repositoryUoW.UserRepository.GetUserByIdAsync(collaboratorDto.UserEntityId);

            if (idUser == null)
                throw new InvalidOperationException("User does not exist!");
        }
    }
}