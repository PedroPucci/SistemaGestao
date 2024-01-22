using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using SistemaGestãoColaboradoresUnidades.Domain.Dto;

namespace SistemaGestaoColaboradoresUnidades.Testes.Dto
{
    public class UserDtoTests
    {
        [Fact(DisplayName = "Create UserDto with valid values")]
        public void CreateUserDto_WithValidValues()
        {
            // Arrange
            var login = "Pedro Ighor";
            var password = "123";
            var status = UserStatus.Active;

            // Act
            var userDto = new UserDto
            {
                Login = login,
                Password = password,
                Status = status
            };

            // Assert
            Assert.NotNull(userDto);
            Assert.Equal(login, userDto.Login);
            Assert.Equal(password, userDto.Password);
            Assert.Equal(status, userDto.Status);
        }
    }
}