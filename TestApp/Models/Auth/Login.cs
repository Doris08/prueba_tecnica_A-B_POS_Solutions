using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.ViewModels;

public class Login
{
    [Required(ErrorMessage = "Correo electrónico es requerido.")]
    public string? Correo { get; set; }

    [Required(ErrorMessage = "Contraseña es requerida.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    
}