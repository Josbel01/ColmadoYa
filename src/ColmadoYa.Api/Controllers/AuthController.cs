using ColmadoYa.Application.DTOs.Auth;
using ColmadoYa.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ColmadoYa.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService auth) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register(
        RegisterRequest request, CancellationToken ct)
    {
        var response = await auth.RegistrarAsync(request, ct);
        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(
        LoginRequest request, CancellationToken ct) =>
        Ok(await auth.LoginAsync(request, ct));

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me() => Ok(new
    {
        Id = User.FindFirst("sub")?.Value,
        Email = User.FindFirst("email")?.Value,
        Nombre = User.FindFirst("name")?.Value,
        Rol = User.FindFirst("role")?.Value
    });

    // Temporal: solo para comprobar que los roles funcionan. Lo borraremos después.
    [Authorize(Roles = "Colmado")]
    [HttpGet("solo-colmados")]
    public IActionResult SoloColmados() => Ok("Eres un colmado autenticado.");
}