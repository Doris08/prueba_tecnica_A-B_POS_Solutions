using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Models;

public class Usuario : IdentityUser
{
    [Required]
    [MaxLength(250)]
    public string Nombres { get; set; } = null!;

    [Required]
    [MaxLength(250)]
    public string Apellidos { get; set; } = null!;

}