using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Comentarios;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAP.Controllers
{

    public class ComentarioController : MiControllerBase
    {
        [HttpPost]

        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }
    }
}