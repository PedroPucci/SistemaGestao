using System.ComponentModel.DataAnnotations;
using SistemaGestãoColaboradoresUnidades.Domain.Entity;

namespace SistemaGestãoColaboradoresUnidades.Domain.Dto
{
    public class CollaboratorEntityDto
    {
        [Required]
        public string? Name { get; set; }    

        [Required]
        public UnityEntity? UnityEntity { get; set; }
    }
}