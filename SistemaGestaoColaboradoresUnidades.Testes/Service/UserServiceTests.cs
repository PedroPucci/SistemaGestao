using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;
using SistemaGestãoColaboradoresUnidades.Repository.Repository.Interfaces;
using SistemaGestãoColaboradoresUnidades.Service.Service;

namespace SistemaGestaoColaboradoresUnidades.Testes.Service
{
    public class UserServiceTests
    {
        [Fact(DisplayName = "Create a user as Success")]
        public async Task AddUser_Success()
        {
            // Arrange
            var userDto = CreateUserDto();
            var userEntity = CreateUserEntity();

            var mockRepositoryUoW = new Mock<IRepositoryUoW>();
            var mockUserRepository = new Mock<IUserRepository>();

            mockRepositoryUoW.Setup(uow => uow.UserRepository).Returns(mockUserRepository.Object);
            mockUserRepository.Setup(repo => repo.AddUserAsync(It.IsAny<UserEntity>())).ReturnsAsync(userEntity);
            mockRepositoryUoW.Setup(uow => uow.SaveAsync());
            var mapper = new Mock<IMapper>();
            var mockDbContextTransaction = new Mock<IDbContextTransaction>();
            mockRepositoryUoW.Setup(uow => uow.BeginTransaction()).Returns(mockDbContextTransaction.Object);

            mapper.Setup(m => m.Map<UserDto, UserEntity>(userDto)).Returns(userEntity);

            var userService = new UserService(mockRepositoryUoW.Object, mapper.Object);

            // Act
            var result = await userService.AddUser(userDto);

            // Assert
            Assert.Equal(userEntity, result);
            mockUserRepository.Verify(repo => repo.AddUserAsync(userEntity), Times.Once);
            mockRepositoryUoW.Verify(uow => uow.SaveAsync(), Times.Once);
            mockRepositoryUoW.Verify(uow => uow.BeginTransaction(), Times.Once);
        }

        private UserDto CreateUserDto()
        {
            return new UserDto { Login = "Pedro", Password = "password123", Status = UserStatus.Active };
        }

        private UserEntity CreateUserEntity()
        {
            return new UserEntity { Login = "Pedro", Password = "password123", Status = UserStatus.Active };
        }
    }
}