using ColmadoYa.Application.Interfaces;
using ColmadoYa.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ColmadoYa.Infrastructure.Auth;

public class AppPasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<Usuario> _hasher = new();

    public string Hashear(string password) =>
        _hasher.HashPassword(null!, password);

    public bool Verificar(string password, string hash) =>
        _hasher.VerifyHashedPassword(null!, hash, password) != PasswordVerificationResult.Failed;
}