using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestaoColaboradoresUnidades.Testes.Entities
{
    public class UnityEntityTests
    {
        [Fact(DisplayName = "Create UnityEntity with custom values")]
        public void CreateUnityEntity_WithCustomValues()
        {
            // Arrange
            var code = 1;
            var name = "Unidade 1 - Tecnologia";

            // Act
            var unityEntity = new UnityEntity
            {
                Code = code,
                Name = name
            };

            // Assert
            Assert.NotNull(unityEntity);
            Assert.Equal(code, unityEntity.Code);
            Assert.Equal(name, unityEntity.Name);
            Assert.False(unityEntity.Inactivated);
            Assert.Null(unityEntity.CollectionCollaboratorEntity);
        }

        [Fact(DisplayName = "Create UnityEntity with default values")]
        public void CreateUnityEntity_WithDefaultValues()
        {
            // Arrange & Act
            var unityEntity = new UnityEntity();

            // Assert
            Assert.NotNull(unityEntity);
            Assert.Null(unityEntity.Code);
            Assert.Null(unityEntity.Name);
            Assert.False(unityEntity.Inactivated);
            Assert.Null(unityEntity.CollectionCollaboratorEntity);
        }
    }
}