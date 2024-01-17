using SistemaGestãoColaboradoresUnidades.Domain.Constant;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestãoColaboradoresUnidades.Domain.Dto
{
    public class UserEntityDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public StatusUser StatusUser { get; set; }
    }
}