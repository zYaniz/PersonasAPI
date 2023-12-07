using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonasAPI.Entities;

// Yani Joel Solano Flores
// Harold Steven Monge Cascante
// Melvin Fernando Mora Delgado 
// Asignacion #3 API personas

# region Metodos.
namespace PersonasAPI.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options): base(options) { }
        public DbSet<PersonaModel> Personas { get; set; }


        #region Método para insertar personas, se pide nombre, apellido y cédula
        public void InsertarPersona(string nombre, string apellido, string cedula)
        {
            Database.ExecuteSqlRaw("EXEC InsertarPersona @Nombre, @Apellido, @Cedula",
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellido", apellido),
                new SqlParameter("@Cedula", cedula));
        }
        #endregion

        #region Método para obtener información pidiendo el número de cédula
        public IEnumerable<PersonaModel> ObtenerInformacionPorCedula(string cedula)
        {
            return Personas.FromSqlRaw("EXEC ObtenerInformacionPorCedula @Cedula", new SqlParameter("@Cedula", cedula));
        }
        #endregion

        #region Método para actualizar información de las personas, pide la cédula anterios, nombre nuevo, el apellido nuevo y la nueva cédula
        public void ActualizarInformacionPersona(string cedulaAnterior, string nuevoNombre, string nuevoApellido, string nuevaCedula)
        {
            // llama al procedimiento  ActualizarInformacionPersona en la BD
            Database.ExecuteSqlRaw("EXEC ActualizarInformacionPersona @CedulaAnterior, @NuevoNombre, @NuevoApellido, @NuevaCedula",
                new SqlParameter("@CedulaAnterior", cedulaAnterior),
                new SqlParameter("@NuevoNombre", nuevoNombre),
                new SqlParameter("@NuevoApellido", nuevoApellido),
                new SqlParameter("@NuevaCedula", nuevaCedula));
        }
        #endregion

        #region Método para eliminar la información de la persona, pide únicamente la cédula.
        public void EliminarInformacionPorCedula(string cedula)
        {
            // llama al procedimiento  EliminarInformacionPorCedula en la BD
            Database.ExecuteSqlRaw("EXEC EliminarInformacionPorCedula @Cedula", new SqlParameter("@Cedula", cedula));
        }
        #endregion

        #region Método para que devuelva todas las personas de la consulta a realizar

        public IEnumerable<PersonaModel> ObtenerTodasLasPersonas()
        {
            return Personas.ToList();
        }
        #endregion

        #region Método para obtener persona mediante el Id en la consulta,
        public PersonaModel ObtenerPersonaPorId(int id)
        {
            return Personas.Find(id);
        }
        #endregion
    }
}

#endregion