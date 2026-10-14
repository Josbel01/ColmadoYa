using ColmadoYa.Application.Interfaces;
using ColmadoYa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ColmadoYa.Infrastructure.Persistence.Repositories;

public class UsuarioRepository(AppDbContext db) : IUsuarioRepository
{
    public Task<bool> ExisteEmailAsync(string email, CancellationToken ct = default) =>
        db.Usuarios.AnyAsync(u => u.Email == email, ct);

    public Task<Usuario?> ObtenerPorEmailAsync(string email, CancellationToken ct = default) =>
        db.Usuarios.FirstOrDefaultAsync(u => u.Email == email, ct);

    public async Task AgregarAsync(Usuario usuario, CancellationToken ct = default)
    {
        db.Usuarios.Add(usuario);
        await db.SaveChangesAsync(ct);
    }
}