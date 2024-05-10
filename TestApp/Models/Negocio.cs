using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TestApp.Models;

public class Negocio
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nombre es requerido.")]
    [MaxLength(250)]
    public string Nombre { get; set; } = null!;

    [AllowNull]
    [MaxLength(500)]
    public string Descripcion { get; set; } = null!;

    [Required(ErrorMessage = "Descripción es requerido.")]
    public DateTime FechaCreacion { get; set; }
}