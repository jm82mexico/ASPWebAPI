using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace WebAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiControllerBase : ControllerBase
    {
       private IMediator _mediator;

       protected IMediator Mediator => 
       _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>() );
    }
}