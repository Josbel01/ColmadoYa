using System.ComponentModel.DataAnnotations;
using ColmadoYa.Domain.Enums;

namespace ColmadoYa.Application.DTOs.Auth;

public class RegisterRequest
{
    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Telefono { get; set; }

    [Required]
    public RolUsuario Rol { get; set; }

    // Solo obligatorios si Rol = Colmado
    [StringLength(120)]
    public string? NombreColmado { get; set; }

    [StringLength(250)]
    public string? DireccionColmado { get; set; }
}