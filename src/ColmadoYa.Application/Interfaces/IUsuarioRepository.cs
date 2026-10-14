using ColmadoYa.Domain.Entities;

namespace ColmadoYa.Application.Interfaces;

public interface IUsuarioRepository
{
    Task<bool> ExisteEmailAsync(string email, CancellationToken ct = default);
    Task<Usuario?> ObtenerPorEmailAsync(string email, CancellationToken ct = default);
    Task AgregarAsync(Usuario usuario, CancellationToken ct = default);
}