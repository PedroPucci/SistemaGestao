﻿using System.ComponentModel.DataAnnotations;

namespace SistemaGestãoColaboradoresUnidades.Domain.Dto
{
    public class UnityDto
    {
        [Required]
        public int? Code { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public bool Inactivated { get; set; } = false;
    }
}