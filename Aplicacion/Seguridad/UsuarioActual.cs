using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persitencia;

namespace Aplicacion.Seguridad
{
    public class UsuarioActual
    {
        public class Ejecutar : IRequest<UsuarioData> { }

        public class Manejador : IRequestHandler<Ejecutar, UsuarioData>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly IUsuarioSesion _usuarioSesion;

            private readonly CursosOnlineContext _cursosOnlineContext;

            public Manejador(UserManager<Usuario> userManager, IJwtGenerador jwtGenerador,
            IUsuarioSesion usuarioSesion, CursosOnlineContext cursosOnlineContext)
            {
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _usuarioSesion = usuarioSesion;
                _cursosOnlineContext = cursosOnlineContext;
            }

            public async Task<UsuarioData> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var usuario =
                    await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());

                var resultadoRoles = await _userManager.GetRolesAsync(usuario);
                var listaRoles = new List<string>(resultadoRoles);

                return new UsuarioData
                {
                    NombreCompleto = usuario.NombreCompleto,
                    Email = usuario.Email,
                    UserName = usuario.UserName,
                    Token = _jwtGenerador.CrearToken(usuario, listaRoles),
                    Imagen = null
                };
            }
        }
    }
}