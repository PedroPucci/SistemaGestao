namespace SistemaGestãoColaboradoresUnidades.Domain.Entity
{
    public class CollaboratorEntity : BaseEntity
    {
        public string? Name { get; set; }
        public UnityEntity? UnityEntity { get; set; }
    }
}