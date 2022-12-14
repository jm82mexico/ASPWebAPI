using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Aplicacion.Contratos;
using Aplicacion.ManejadorError;
using Dominio;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persitencia;


namespace Aplicacion.Seguridad
{
    public class Registrar
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public string NombreCompleto { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.NombreCompleto).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly CursosOnlineContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerator;

            public Manejador(CursosOnlineContext context, UserManager<Usuario> userManager, IJwtGenerador jwtGenerador)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerator = jwtGenerador;
            }
            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var existe =
                    await _context.Users.Where(x => x.Email == request.Email).AnyAsync();

                if (existe)
                {
                    throw new ManejadorExcepcion
                    (HttpStatusCode.BadRequest, new { mensaje = "Existe ya un usuario con este email" });
                }

                var existeUserName =
                    await _context.Users.Where(x => x.UserName == request.Username).AnyAsync();
                if (existe)
                {
                    throw new ManejadorExcepcion
                    (HttpStatusCode.BadRequest, new { mensaje = "Existe ya un usuario con este username" });
                }

                var usuario =
                    new Usuario
                    {
                        NombreCompleto = request.NombreCompleto,
                        Email = request.Email,
                        UserName = request.Username
                    };

                var resultado =
                    await _userManager.CreateAsync(usuario, request.Password);

                if (resultado.Succeeded)
                {
                    return new UsuarioData
                    {
                        NombreCompleto = usuario.NombreCompleto,
                        Token = _jwtGenerator.CrearToken(usuario, null),
                        UserName = usuario.UserName,
                        Email = usuario.Email
                    };
                }

                throw new Exception("No se pudo guardar al nuevo usuario");

            }
        }
    }
}