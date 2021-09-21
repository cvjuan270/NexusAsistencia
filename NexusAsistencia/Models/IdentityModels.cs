using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NexusAsistencia.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
       // [Required]
        [StringLength(8)]
        [Display(Name = "DNI")]
        public string Dni { get; set; }
        //[Required]
        [MaxLength(50)]
        [Display(Name = "Nombre y Apellido")]
        public string NomApe { get; set; }

        [MaxLength(9)]
        [Display(Name = "Número de celular")]
        public string NumCel { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? FecNac { get; set; }


        [Display(Name = "Tiempo de jornada")]
        [DataType(DataType.Time)]
        public TimeSpan? HorJor { get; set; }

        [Display(Name = "Refrigerio")]
        public bool Breake { get; set; }
        [Display(Name = "Tiempo de refrigerio")]
        [DataType(DataType.Time)]
        public TimeSpan? HorBre { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IdentityRole>().HasKey(x => x.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(x => x.RoleId);
        //    modelBuilder.Entity<IdentityUserLogin>().HasKey(x => x.UserId);

        //    modelBuilder.Entity<NexusAsistencia.Models.Anexo>().Property(x => x.Latitu).HasPrecision(18, 10);

        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Anexo> Anexoes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }

        public System.Data.Entity.DbSet<NexusAsistencia.Models.Asistencia> Asistencias { get; set; }

        public System.Data.Entity.DbSet<NexusAsistencia.Models.Colaborador> Colaboradors { get; set; }
    }
}