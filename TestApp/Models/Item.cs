using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Nest;
using NuGet.DependencyResolver;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Models;

public class Item
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("CategoriaItem")]
    [Required(ErrorMessage = "Categoría es requerido.")]
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "Negocio es requerido.")]
    public int NegocioId { get; set; }

    [Required(ErrorMessage = "Nombre es requerido.")]
    [MaxLength(250)]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "Precio es requerido.")]
    [Precision(8, 2)]
    public decimal Precio { get; set; }


}