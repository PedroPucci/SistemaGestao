using SistemaGestãoColaboradoresUnidades.Domain.Constant;

namespace SistemaGestãoColaboradoresUnidades.Domain.Entity
{
    public class UserEntity : BaseEntity
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public UserStatus Status { get; set; }
        public ICollection<CollaboratorEntity>? CollectionCollaboratorEntity { get; }
    }
}