using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.ViewModels;

public class Register
{
    [Required(ErrorMessage = "Nombre es requerido.")]
    public string Nombres { get; set; } = null!;

    [Required(ErrorMessage = "Apellido es requerido.")]
    public string Apellidos { get; set; } =  null!;

    [Required(ErrorMessage = "Correo electrónico es requerido.")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Contraseña es requerida.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Compare("Password", ErrorMessage = "Las contraseñas deben coincidir")]
    [Display(Name = "Confirmar Contraseña")]
    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }

}