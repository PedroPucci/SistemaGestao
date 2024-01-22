using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestaoColaboradoresUnidades.Testes.Entities
{
    public class CollaboratorEntityTests
    {
        [Fact(DisplayName = "Create object Collaborator")]
        public void CreateCollaboratorEntity_WithCustomValues()
        {
            // Arrange
            var unityEntityId = 1;
            var userEntityId = 1;
            var name = "Colaborador 1";

            // Act
            var collaboratorEntity = new CollaboratorEntity
            {
                UnityEntityId = unityEntityId,
                UserEntityId = userEntityId,
                Name = name
            };

            // Assert
            Assert.NotNull(collaboratorEntity);
            Assert.Equal(unityEntityId, collaboratorEntity.UnityEntityId);
            Assert.Equal(userEntityId, collaboratorEntity.UserEntityId);
            Assert.Equal(name, collaboratorEntity.Name);
            Assert.NotNull(collaboratorEntity.UnityEntity);
            Assert.NotNull(collaboratorEntity.UserEntity);
        }
    }
}