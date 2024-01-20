using System.ComponentModel.DataAnnotations;

namespace SistemaGestãoColaboradoresUnidades.Domain.Dto
{
    public class CollaboratorDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int UnityEntityId { get; set; }

        [Required]
        public int UserEntityId { get; set; }
    }
}