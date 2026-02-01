using System.ComponentModel.DataAnnotations;

namespace Tarea2.Domain.Entities;

public class Asignatura
{
    [Key]
    public int AsignaturaId { get; set; }

    [Required]
    [StringLength(20)]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Aula { get; set; } = string.Empty;

    [Required]
    [Range(1, 10)]
    public int Creditos { get; set; }
}

