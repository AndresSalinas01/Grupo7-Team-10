using HormonaDeCrecimiento.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace HormonaDeCrecimiento.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas{get;set;}
        public DbSet<Medico> Medicos{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SHELBY\\SQLEXPRESS;Initial Catalog=HormonaDeCrecimientoT10;Integrated Security=False;trusted_connection=true;");
            }
        }
    }
}