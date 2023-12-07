using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonasAPI.Contexto;
using PersonasAPI.Entities;

namespace PersonasAPI.Controllers
{
    [Route("personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ContextoBD _dbContext;
        public PersonasController(ContextoBD dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("ObtenerNombrePorCedula")]
        public ActionResult<IEnumerable<PersonaModel>> ConsultaPersonaPorCedula([FromQuery] string cedula)
        {
            var personas = _dbContext.ConsultaPersonas(cedula);
            return Ok(personas);
        }

        [HttpGet]
        [Route("obtenerNombrePersona")]
        public dynamic obtenerNombrePorCedula()
        {
            return new
            {
                nombre = "Jafeth AM"
            };
        }
    }
}
