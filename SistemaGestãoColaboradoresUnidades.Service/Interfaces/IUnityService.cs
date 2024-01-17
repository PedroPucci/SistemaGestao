﻿using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Service.Interfaces
{
    public interface IUnityService
    {
        Task<UnityEntity> UpdateUnityEntity(UnityEntityDto unityEntityDto);
        Task<List<UnityEntity>> GetAllUnityEntites();
    }
}