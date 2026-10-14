using ColmadoYa.Application.Common.Exceptions;
using ColmadoYa.Application.DTOs.Auth;
using ColmadoYa.Application.Interfaces;
using ColmadoYa.Domain.Entities;
using ColmadoYa.Domain.Enums;

namespace ColmadoYa.Application.Services;

public class AuthService(
    IUsuarioRepository usuarios,
    IPasswordHasher hasher,
    IJwtTokenGenerator jwt) : IAuthService
{
    public async Task<AuthResponse> RegistrarAsync(RegisterRequest request, CancellationToken ct = default)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        if (await usuarios.ExisteEmailAsync(email, ct))
            throw new ConflictException("Ya existe una cuenta con ese correo.");

        if (request.Rol == RolUsuario.Colmado &&
            (string.IsNullOrWhiteSpace(request.NombreColmado) ||
             string.IsNullOrWhiteSpace(request.DireccionColmado)))
            throw new ReglaNegocioException("Un colmado necesita nombre y dirección.");

        var usuario = new Usuario
        {
            Nombre = request.Nombre.Trim(),
            Email = email,
            PasswordHash = hasher.Hashear(request.Password),
            Telefono = request.Telefono,
            Rol = request.Rol
        };

        if (request.Rol == RolUsuario.Colmado)
        {
            usuario.Colmado = new Colmado
            {
                Nombre = request.NombreColmado!.Trim(),
                Direccion = request.DireccionColmado!.Trim(),
                Telefono = request.Telefono
            };
        }

        await usuarios.AgregarAsync(usuario, ct);
        return CrearRespuesta(usuario);
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken ct = default)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        var usuario = await usuarios.ObtenerPorEmailAsync(email, ct);

        if (usuario is null || !hasher.Verificar(request.Password, usuario.PasswordHash))
            throw new CredencialesInvalidasException("Correo o contraseña incorrectos.");

        return CrearRespuesta(usuario);
    }

    private AuthResponse CrearRespuesta(Usuario usuario)
    {
        var token = jwt.Generar(usuario);
        return new AuthResponse
        {
            UsuarioId = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            Rol = usuario.Rol.ToString(),
            Token = token.Token,
            ExpiraEn = token.ExpiraEn
        };
    }
}