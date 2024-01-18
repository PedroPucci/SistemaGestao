using System.ComponentModel.DataAnnotations;

namespace SistemaGestãoColaboradoresUnidades.Domain.Dto
{
    public class UnityEntityDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int? Code { get; set; }
    }
}