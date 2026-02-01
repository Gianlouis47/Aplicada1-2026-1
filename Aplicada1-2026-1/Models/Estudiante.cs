using System;
using System.ComponentModel.DataAnnotations;

namespace Aplicada1_2026_1.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        [StringLength(50)]
        public string? Matricula { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }
    }
}
