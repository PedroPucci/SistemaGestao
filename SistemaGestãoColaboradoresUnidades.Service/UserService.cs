using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
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

        public async Task<UserEntity> AddUserEntity(UserEntityDto userEntityDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                UserEntity userEntity = _mapper.Map<UserEntityDto, UserEntity>(userEntityDto);
                var result = await _repositoryUoW.UserRepository.AddUserEntityAsync(userEntity);

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

        public async Task<UserEntity> UpdateUserEntity(UserEntityDto userEntityDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                UserEntity userEntity = _mapper.Map<UserEntityDto, UserEntity>(userEntityDto);
                UserEntity? userEntityByLogin = await _repositoryUoW.UserRepository.GetUserEntityByLoginAsync(userEntity);

                if (userEntityByLogin == null)
                    return null;

                userEntityByLogin.Password = userEntityDto.Password;
                userEntityByLogin.StatusUser = userEntityDto.StatusUser;

                var result = _repositoryUoW.UserRepository.UpdateUserEntity(userEntityByLogin);

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

        public async Task<List<UserEntity>> GetAllUserEntities()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<UserEntity> userEntities = await _repositoryUoW.UserRepository.GetAllUserEntitiesAsync();
                _repositoryUoW.Commit();
                return userEntities;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
        }

        public async Task<List<UserEntity>> GetAllUserEntityByStatus(StatusUser statusUser)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<UserEntity> userEntities = await _repositoryUoW.UserRepository.GetAllUserEntityByStatusAsync(statusUser);
                _repositoryUoW.Commit();
                return userEntities;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new InvalidOperationException("Unexpected error " + ex + "!");
            }
        }
    }
}