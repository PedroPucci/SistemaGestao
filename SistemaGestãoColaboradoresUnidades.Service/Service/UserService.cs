using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Domain.Enums.Errors;
using SistemaGestãoColaboradoresUnidades.Domain.Helpers;
using SistemaGestãoColaboradoresUnidades.Domain.Validator;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Service.Interfaces;

namespace SistemaGestãoColaboradoresUnidades.Service.Service
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
        }

        public async Task<UserEntity> AddUser(UserDto userDto)
        {
            var userValidation = await new UserDtoValidator().ValidateAsync(userDto);

            if (!userValidation.IsValid)
            {
                throw new InvalidOperationException("Invalid Parameters!");             
            }

            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                var userEntity = _mapper.Map<UserDto, UserEntity>(userDto);
                var result = await _repositoryUoW.UserRepository.AddUserAsync(userEntity);

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

        public async Task<UserEntity> UpdateUser(UserDto userDto)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                UserEntity userEntity = _mapper.Map<UserDto, UserEntity>(userDto);
                UserEntity? userEntityByLogin = await _repositoryUoW.UserRepository.GetUserByLoginAsync(userEntity);

                if (userEntityByLogin == null)
                    return null;

                userEntityByLogin.Password = userDto.Password;
                userEntityByLogin.Status = userDto.Status;

                var result = _repositoryUoW.UserRepository.UpdateUser(userEntityByLogin);

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

        public async Task<List<UserEntity>> GetAllUsers()
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<UserEntity> userList = await _repositoryUoW.UserRepository.GetAllUsersAsync();
                _repositoryUoW.Commit();
                return userList;
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

        public async Task<List<UserEntity>> GetAllUsersByStatus(UserStatus userStatus)
        {
            using var transaction = _repositoryUoW.BeginTransaction();
            try
            {
                List<UserEntity> userList = await _repositoryUoW.UserRepository.GetAllUsersByStatusAsync(userStatus);
                _repositoryUoW.Commit();
                return userList;
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