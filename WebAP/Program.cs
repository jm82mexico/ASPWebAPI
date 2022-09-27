using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persitencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio;
using Microsoft.AspNetCore.Identity;

namespace WebAP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostserver = CreateHostBuilder(args).Build();
            using(var ambiente = hostserver.Services.CreateScope())
            {
                var services = ambiente.ServiceProvider;
                 try
                 {
                    var userManager = services.GetRequiredService<UserManager<Usuario>>();
                    var context = services.GetRequiredService<CursosOnlineContext>();
                    context.Database.Migrate();
                    // * SE COLOCA WAIT YA QUE MAIN NO SE PUEDE COLOCAR COMO ESTATICO
                    DataPrueba.InsetarData(context,userManager).Wait();
                 }
                 catch (System.Exception ex)
                 {
                    var Logging = services.GetRequiredService<ILogger<Program>>();
                    Logging.LogError(ex,"Ocurrio un error en la migracion");
                    
                 }
            }
            hostserver.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
