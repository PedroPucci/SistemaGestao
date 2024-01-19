using AutoMapper;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Repository
{
    public class Mappers : Profile
    {
        public Mappers() { }

        public MapperConfiguration Configuration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, UserDto>();
                cfg.CreateMap<UserDto, UserEntity>();

                cfg.CreateMap<UnityEntity, UnityDto>();
                cfg.CreateMap<UnityDto, UnityEntity>();

                cfg.CreateMap<CollaboratorEntity, CollaboratorDto>();
                cfg.CreateMap<CollaboratorDto, CollaboratorEntity>();
            });
        }
    }
}