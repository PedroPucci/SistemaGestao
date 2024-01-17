﻿using SistemaGestãoColaboradoresUnidades.Domain;

namespace SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> AddUserEntity(UserEntity userEntity);
        UserEntity UpdateUserEntity(UserEntity userEntity);
    }
}