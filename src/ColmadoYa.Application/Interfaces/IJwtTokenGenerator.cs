using ColmadoYa.Domain.Entities;

namespace ColmadoYa.Application.Interfaces;

public record TokenGenerado(string Token, DateTime ExpiraEn);

public interface IJwtTokenGenerator
{
    TokenGenerado Generar(Usuario usuario);
}