using System;
using System.Data.Entity;
using System.Linq;

namespace NexusAsistencia.Models
{
    public class NexusContext : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'NexusContext' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'NexusAsistencia.Models.NexusContext' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'NexusContext'  en el archivo de configuración de la aplicación.
        public NexusContext()
            : base("name=NexusContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<NexusAsistencia.Models.Anexo>().Property(x => x.Latitu).HasPrecision(18, 10);
            //modelBuilder.Entity<NexusAsistencia.Models.Anexo>().Property(x => x.Longit).HasPrecision(18, 10);
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        //public virtual DbSet<Anexo> Anexoes { get; set; }
        //public virtual DbSet<Empresa> Empresas { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}