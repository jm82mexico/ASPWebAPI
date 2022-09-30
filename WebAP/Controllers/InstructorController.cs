using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Instructores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persitencia.DapperConexion.Instructor;

namespace WebAP.Controllers
{

    public class InstructorController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<InstructorModel>>> ObtenerInstructores()
        {
            return await Mediator.Send(new Consulta.Lista());
        }
    }
}