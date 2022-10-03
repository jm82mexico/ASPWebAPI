using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Dominio;
using Aplicacion.ManejadorError;
using System.Net;

namespace Aplicacion.Seguridad
{
    public class UsuarioRolEliminar
    {
        public class Ejecuta : IRequest
        {
            public string UserName { get; set; }
            public string RolNombre { get; set; }
        }

        public class EjecutaValida : AbstractValidator<Ejecuta>
        {
            public EjecutaValida()
            {
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.RolNombre).NotEmpty();

            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public Manejador(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(request.RolNombre);
                if (role == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se encontró el rol" });
                }

                var usuarioIden = await _userManager.FindByNameAsync(request.UserName);
                if (usuarioIden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "No se encontró el usuaio" });
                }

                var resultado = await _userManager.RemoveFromRoleAsync(usuarioIden, request.RolNombre);
                if (resultado.Succeeded)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el rol");
            }
        }
    }
}