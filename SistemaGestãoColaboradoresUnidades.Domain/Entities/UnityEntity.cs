namespace SistemaGestãoColaboradoresUnidades.Domain.Entity
{
    public class UnityEntity : BaseEntity
    {
        public int? Code { get; set; }
        public string? Name {  get; set; }
        public bool Inactivated { get; set; } = false;
        public ICollection<CollaboratorEntity>? CollectionCollaboratorEntity { get;}
    }
}