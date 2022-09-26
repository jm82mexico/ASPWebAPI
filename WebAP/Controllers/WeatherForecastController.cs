using Microsoft.AspNetCore.Mvc;
using Persitencia;
using Dominio;
namespace WebAP.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly CursosOnlineContext context;

    public WeatherForecastController(CursosOnlineContext _context)
    {
        this.context = _context;
    }

    [HttpGet]
    public IEnumerable<Curso> Get()
    {

        return context.Curso.ToList();
    }



}
