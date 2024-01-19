using System.ComponentModel.DataAnnotations;

namespace SistemaGestãoColaboradoresUnidades.Domain.Entity
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; private set; }        

        protected BaseEntity(){}
    }
}