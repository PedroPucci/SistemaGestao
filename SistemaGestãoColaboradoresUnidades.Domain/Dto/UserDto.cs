using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestãoColaboradoresUnidades.Domain.Dto
{
    public class UserDto
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public UserStatus Status { get; set; }
    }
}