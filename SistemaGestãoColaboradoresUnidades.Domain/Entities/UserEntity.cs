using SistemaGestãoColaboradoresUnidades.Domain.Constant;

namespace SistemaGestãoColaboradoresUnidades.Domain.Entity
{
    public class UserEntity : BaseEntity
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public StatusUser StatusUser { get; set; }
    }
}