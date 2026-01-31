using System.ComponentModel.DataAnnotations;

namespace Tarea3.Models;

public sealed class TiposPuntos
{
    [Key]
    public int TipoId { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required, StringLength(300)]
    public string Descripcion { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int ValorPuntos { get; set; }

    [Required, StringLength(30)]
    public string Color { get; set; } = string.Empty;

    [Required, StringLength(60)]
    public string Icono { get; set; } = string.Empty;

    public bool Activo { get; set; }
}
