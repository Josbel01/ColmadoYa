# ColmadoYa

App móvil de pedidos a domicilio para colmados y negocios locales.

## Stack
- .NET MAUI (app móvil)
- ASP.NET Core Web API
- Entity Framework Core + SQL Server
- Arquitectura Onion / Clean

## Estructura
- src/ColmadoYa.Domain: entidades y reglas de negocio
- src/ColmadoYa.Application: casos de uso e interfaces
- src/ColmadoYa.Infrastructure: acceso a datos y servicios
- src/ColmadoYa.Api: API REST
- src/ColmadoYa.Mobile: app MAUI
