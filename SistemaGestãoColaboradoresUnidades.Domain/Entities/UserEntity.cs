﻿using SistemaGestãoColaboradoresUnidades.Domain.Constant;

namespace SistemaGestãoColaboradoresUnidades.Domain.Entity
{
    public class UserEntity : BaseEntity
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
        public StatusUser StatusUser { get; set; }
        public ICollection<ICollection<CollaboratorEntity>> CollectionCollaboratorEntity { get; } = new List<ICollection<CollaboratorEntity>>();
    }
}