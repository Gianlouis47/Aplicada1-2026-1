using System.ComponentModel.DataAnnotations;

namespace Aplicada1_2026_1.Models;

public class Estudiante
{
    [Key]
    public int EstudianteId { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Apellido { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    [StringLength(50)]
    public string? Matricula { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? Telefono { get; set; }
}
