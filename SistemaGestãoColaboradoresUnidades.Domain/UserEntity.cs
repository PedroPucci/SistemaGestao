using SistemaGestãoColaboradoresUnidades.Domain.Constant;

namespace SistemaGestãoColaboradoresUnidades.Domain
{
    public class UserEntity : BaseModel
    {
        public string? Login {  get; set; }
        public string? Password {  get; set; }
        public StatusUser StatusUser { get; set; }
    }
}