namespace SistemaGestãoColaboradoresUnidades.Domain.Entity
{
    public class CollaboratorEntity : BaseEntity
    {
        public string? Name { get; set; }
        public int UnityEntityId { get; set; }
        public UnityEntity UnityEntity { get; } = new UnityEntity();
        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; } = new UserEntity();
    }
}