using SistemaGestãoColaboradoresUnidades.Domain.Dto;

namespace SistemaGestaoColaboradoresUnidades.Testes.Dto
{
    public class UnityDtoTests
    {
        [Fact(DisplayName = "Create UnityDto with valid values")]
        public void CreateUnityDto_WithValidValues()
        {
            // Arrange
            var code = 1;
            var name = "Unidade 1";
            var inactived = false;

            // Act
            var unityDto = new UnityDto
            {
                Code = code,
                Name = name,
                Inactivated = inactived
            };

            // Assert
            Assert.NotNull(unityDto);
            Assert.Equal(code, unityDto.Code);
            Assert.Equal(name, unityDto.Name);
            Assert.Equal(inactived, unityDto.Inactivated);
        }
    }
}