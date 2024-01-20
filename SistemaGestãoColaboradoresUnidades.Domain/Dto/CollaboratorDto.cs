using System.ComponentModel.DataAnnotations;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Domain.Dto
{
    public class CollaboratorDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public int UnityEntityId { get; set; }

        [Required]
        public int UserEntityId { get; set; }
    }
}