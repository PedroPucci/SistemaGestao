using SistemaGestãoColaboradoresUnidades.Domain.Constant;

namespace SistemaGestaoColaboradoresUnidades.Testes.Enums
{
    public class UserStatusTests
    {
        [Fact(DisplayName = "UserStatus should have Inactive value")]
        public void UserStatus_ShouldHaveInactiveValue()
        {
            // Arrange & Act
            var status = UserStatus.Inactive;

            // Assert
            Assert.Equal(0, (ushort)status);
            Assert.Equal("Inactive", status.ToString());
        }

        [Fact(DisplayName = "UserStatus should have Active value")]
        public void UserStatus_ShouldHaveActiveValue()
        {
            // Arrange & Act
            var status = UserStatus.Active;

            // Assert
            Assert.Equal(1, (ushort)status);
            Assert.Equal("Active", status.ToString());
        }

        [Fact(DisplayName = "UserStatus values should be distinct")]
        public void UserStatus_ValuesShouldBeDistinct()
        {
            // Arrange & Act
            var inactiveStatus = UserStatus.Inactive;
            var activeStatus = UserStatus.Active;

            // Assert
            Assert.NotEqual(inactiveStatus, activeStatus);
        }
    }
}