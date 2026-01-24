using System.ComponentModel.DataAnnotations;

namespace Tarea2.Domain.Entities;

public class Asignatura
{
    public int AsignaturaId { get; set; }

    [Required]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Aula { get; set; } = string.Empty;

    [Required]
    public int Creditos { get; set; }
}

