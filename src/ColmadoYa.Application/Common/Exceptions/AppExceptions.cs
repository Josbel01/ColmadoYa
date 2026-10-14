using System;
using System.Collections.Generic;
using System.Text;

namespace ColmadoYa.Application.Common.Exceptions
{
    public class AppExceptions
    {
    }
    // 400: se rompió una regla de negocio
    public class ReglaNegocioException(string mensaje) : Exception(mensaje);

    // 409: el recurso ya existe
    public class ConflictException(string mensaje) : Exception(mensaje);

    // 401: credenciales incorrectas
    public class CredencialesInvalidasException(string mensaje) : Exception(mensaje);
}
