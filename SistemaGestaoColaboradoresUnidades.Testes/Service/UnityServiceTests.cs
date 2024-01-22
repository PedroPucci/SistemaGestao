using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Service;

namespace SistemaGestaoColaboradoresUnidades.Testes.Service
{
    public class UnityServiceTests
    {
        [Fact(DisplayName = "AddUnity should add unity")]
        public async Task AddUnity_Success()
        {
            // Arrange
            var unityDto = CreateUnityDto();
            var unityEntity = CreateUnityEntity();

            var mockRepositoryUoW = new Mock<IRepositoryUoW>();
            var mockUnityRepository = new Mock<IUnityRepository>();

            mockRepositoryUoW.Setup(uow => uow.UnityRepository).Returns(mockUnityRepository.Object);
            mockUnityRepository.Setup(repo => repo.AddUnityAsync(It.IsAny<UnityEntity>())).ReturnsAsync(unityEntity);
            mockRepositoryUoW.Setup(uow => uow.SaveAsync());
            var mapper = new Mock<IMapper>();
            var mockDbContextTransaction = new Mock<IDbContextTransaction>();
            mockRepositoryUoW.Setup(uow => uow.BeginTransaction()).Returns(mockDbContextTransaction.Object);

            mapper.Setup(m => m.Map<UnityDto, UnityEntity>(unityDto)).Returns(unityEntity);

            var unityService = new UnityService(mockRepositoryUoW.Object, mapper.Object);

            // Act
            var result = await unityService.AddUnity(unityDto);

            // Assert
            Assert.Equal(unityEntity, result);
            mockUnityRepository.Verify(repo => repo.AddUnityAsync(unityEntity), Times.Once);
            mockRepositoryUoW.Verify(uow => uow.SaveAsync(), Times.Once);
            mockRepositoryUoW.Verify(uow => uow.BeginTransaction(), Times.Once);
        }

        private UnityDto CreateUnityDto()
        {            
            return new UnityDto { Code = 1, Name = "Unidade 1" };
        }

        private UnityEntity CreateUnityEntity()
        {            
            return new UnityEntity { Code = 1, Name = "Unidade 1", Inactivated = false };
        }
    }
}