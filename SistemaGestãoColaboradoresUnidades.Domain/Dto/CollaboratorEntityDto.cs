using System.ComponentModel.DataAnnotations;

namespace SistemaGestãoColaboradoresUnidades.Domain.Dto
{
    public class CollaboratorEntityDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }    

        [Required]
        public UnityEntity? UnityEntity { get; set; }
    }
}