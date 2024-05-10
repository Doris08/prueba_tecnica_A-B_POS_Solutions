using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Models;

public class CategoriaItem
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nombre de la categoria es requerido.")]
    [MaxLength(250)]
    public string Nombre { get; set; } = null!;

}