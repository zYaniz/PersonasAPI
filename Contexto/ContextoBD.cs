using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonasAPI.Entities;

namespace PersonasAPI.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options): base(options) { }
        public DbSet<PersonaModel> Personas { get; set; }
        public IEnumerable<PersonaModel> ConsultaPersonas(string cedula)
        {
            return Personas.FromSqlRaw("EXEC ObtenerInformacionPorCedula @Cedula", new SqlParameter("@Cedula",cedula));
        }
    }
}
