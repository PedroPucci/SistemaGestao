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
                cfg.CreateMap<UserEntity, UserEntityDto>();
                cfg.CreateMap<UserEntityDto, UserEntity>();

                cfg.CreateMap<UnityEntity, UnityEntityDto>();
                cfg.CreateMap<UnityEntityDto, UnityEntity>();

                cfg.CreateMap<CollaboratorEntity, CollaboratorEntityDto>();
                cfg.CreateMap<CollaboratorEntityDto, CollaboratorEntity>();
            });
        }
    }
}