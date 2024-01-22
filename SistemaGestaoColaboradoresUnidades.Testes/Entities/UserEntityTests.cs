using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestaoColaboradoresUnidades.Testes.Entities
{
    public class UserEntityTests
    {
        [Fact(DisplayName = "Create UserEntity with custom values")]
        public void CreateUserEntity_WithCustomValues()
        {
            // Arrange
            var login = "Pedro Ighor";
            var password = "passWord123";
            var status = UserStatus.Active;

            // Act
            var userEntity = new UserEntity
            {
                Login = login,
                Password = password,
                Status = status
            };

            // Assert
            Assert.NotNull(userEntity);
            Assert.Equal(login, userEntity.Login);
            Assert.Equal(password, userEntity.Password);
            Assert.Equal(status, userEntity.Status);
            Assert.Null(userEntity.CollectionCollaboratorEntity);
        }

        [Fact(DisplayName = "Create UserEntity with default values")]
        public void CreateUserEntity_WithDefaultValues()
        {
            // Arrange & Act
            var userEntity = new UserEntity();

            // Assert
            Assert.NotNull(userEntity);
            Assert.Null(userEntity.Login);
            Assert.Null(userEntity.Password);
            Assert.Equal(UserStatus.Inactive, userEntity.Status);
            Assert.Null(userEntity.CollectionCollaboratorEntity);
        }
    }
}