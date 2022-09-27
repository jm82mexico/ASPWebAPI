using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Dominio;
using Microsoft.AspNetCore.Identity;
using Persitencia;
using FluentValidation;
using Aplicacion.ManejadorError;
using System.Net;
namespace Aplicacion.Seguridad
{
    public class Login
    {
        public class Ejecuta : IRequest<Usuario>{
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta, Usuario>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly SignInManager<Usuario> _signInManager;

            private readonly CursosOnlineContext _context;
            public Manejador(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager,
            CursosOnlineContext context)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _context = context;
            }
            public async Task<Usuario> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
               var usuario = await _userManager.FindByEmailAsync(request.Email);

               if(usuario == null)
               {
                    throw new ManejadorExcepcion(HttpStatusCode.Unauthorized);
               }

               var resultado = await _signInManager.CheckPasswordSignInAsync(usuario,request.Password,false);

               if(resultado.Succeeded)
               {
                    return usuario;
               }

               throw new ManejadorExcepcion(HttpStatusCode.Unauthorized);
            }
        }
    }
}