using ColmadoYa.Application.DTOs.Auth;

namespace ColmadoYa.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegistrarAsync(RegisterRequest request, CancellationToken ct = default);
    Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken ct = default);
}