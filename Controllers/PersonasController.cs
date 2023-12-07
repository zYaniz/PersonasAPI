using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonasAPI.Contexto;
using PersonasAPI.Entities;


// Yani Joel Solano Flores
// Harold Steven Monge Cascante
// Melvin Fernando Mora Delgado 
// Asignacion #3 API personas


#region controladores Persona 

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

        #region Obtener todos los registros de todas las personas
        [HttpGet]
        [Route("obtenerTodasPersonas")]
        public ActionResult<IEnumerable<PersonaModel>> ObtenerTodasLasPersonas()
        {
            // referencia a ObtenerTodasLasPersonas en ContextoBD.cs
            var personas = _dbContext.ObtenerTodasLasPersonas();
            return Ok(personas);
        }

        #endregion

        #region   Obtiene la persona mediante el ID
        [HttpGet("{id}")]
        [Route("obtenerPersonaPorID")]

        public ActionResult<PersonaModel> ObtenerPersonaPorId(int id)
        {
            // Si no se encuentra, aparece que no se encontró, si se encuentra, aparece la persona
            var persona = _dbContext.ObtenerPersonaPorId(id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        #endregion


        #region  Agrega la persona, se pide el nombre, apellido y cèdula
        [HttpPost]
        [Route("agregarPersona")]
        public IActionResult AgregarPersona([FromBody] PersonaModel persona)
        {
            _dbContext.InsertarPersona(persona.Nombre, persona.Apellido, persona.Cedula);

            return CreatedAtAction(nameof(ObtenerPersonaPorId), new { id = persona.Id }, persona);
        }


        #endregion


        #region Actualiza los datos de la persona por ID
        [HttpPut("{id}")]
        [Route("actualizarPersona")]

        public IActionResult ActualizarPersona(int id, [FromBody] PersonaModel personaActualizada)
        {
            _dbContext.ActualizarInformacionPersona(personaActualizada.Cedula, personaActualizada.Nombre, personaActualizada.Apellido, personaActualizada.Cedula);

            return NoContent();
        }
        #endregion

        #region Elimina a la persona por ID
        [HttpDelete("{id}")]
        [Route("eliminarPersona")]
        public IActionResult EliminarPersona(int id)
        {
            _dbContext.EliminarInformacionPorCedula(id.ToString());
            return NoContent();
        }
        #endregion
    }
}
#endregion