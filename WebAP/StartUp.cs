using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persitencia;
using MediatR;
using Aplicacion.Cursos;
using FluentValidation.AspNetCore;
using WebAP.Middleware;
using Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;
using Aplicacion.Contratos;
using Seguridad;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Seguridad.TokenSeguridad;
using AutoMapper;
using Persitencia.DapperConexion;
using Persitencia.DapperConexion.Instructor;
using Microsoft.OpenApi.Models;
using Persitencia.DapperConexion.Paginacion;

namespace WebAP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // * CONFIGURACIÓN PARA LA CONEXIÓN A LA BASE DE DATOS
            services.AddDbContext<CursosOnlineContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            // * CONFIGURACION DE LA CONEXIÓN DE LA BASE DE DATOS CON STORED PROCEDURES
            services.AddOptions();
            services.Configure<ConexionConfiguracion>(Configuration.GetSection("ConnectionStrings"));
            services.AddTransient<IFactoryConnection, FactoryConnection>();
            services.AddScoped<IInstructor, InstructorRepositorio>();
            services.AddScoped<IPaginacion, PaginacionRepositorio>();

            // * CONFIGURACIÓNN PARA LA INYECCIÓN DE DEPENDENCIAS
            services.AddMediatR(typeof(Consulta.Manejador).Assembly);
            // * AGREGAR SEGURIDAD A TODOS LOS CONTROLADORES
            services.AddControllers(
                opt =>
                {
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    opt.Filters.Add(new AuthorizeFilter(policy));
                }
            //* CONFIGURACION PARA LA VALIDACIÓN CON FLUENT
            ).AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());


            // *CONFIGURACIÓN PARA EL USO DE IDENTITY
            var builder = services.AddIdentityCore<Usuario>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddEntityFrameworkStores<CursosOnlineContext>();
            identityBuilder.AddSignInManager<SignInManager<Usuario>>();
            services.TryAddSingleton<ISystemClock, SystemClock>();

            // *CONFIGURACIÓN DE LA AUTENTICACIÓN POR TOKEN
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PelucheCachorriux"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false, //Validación por IP's
                        ValidateIssuer = false
                    };
            });
            // * CONFIGURACION PARA JWT
            services.AddScoped<IJwtGenerador, JwtGenerador>();
            // * RECUPERAR LA INFORMACIÓN DEL USUARIO
            services.AddScoped<IUsuarioSesion, UsuarioSesion>();
            // * CONFIGUACIÓN AUTOMAPPER
            services.AddAutoMapper(typeof(Consulta.Manejador));

            // *AGREGAR SWAGGEER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Services de mantenimiento de cursos",
                    Version = "v1"
                });
                c.CustomSchemaIds(c => c.FullName);

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ManejadorErrorMiddleware>();
            if (env.IsDevelopment())
            {
                // ! SE DESHABILITA POR LA CREACIÓN DEL MIDDLEWARE PARA MANEJO DE ERRORES
                // app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cursos Online v1");
            });
        }
    }

}