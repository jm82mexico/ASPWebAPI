using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity;

namespace Persitencia
{
    public class DataPrueba
    {
        public static async Task InsetarData(CursosOnlineContext context,UserManager<Usuario> usuarioManager)
        {
            if(!usuarioManager.Users.Any())
            {
                var usuario = new Usuario{
                    NombreCompleto = "Juan Del Angel",
                    UserName = "jangel",
                    Email = "jagel@hircasa.com"
                };
                await usuarioManager.CreateAsync(usuario,"Camus2514*");
            }
        }
    }
}