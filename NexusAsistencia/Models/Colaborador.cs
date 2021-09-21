using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NexusAsistencia.Models
{
    public class Colaborador
    {
        [StringLength(8)]
        [Key]
        [Display(Name = "DNI")]
        public string Dni { get; set; }
        public string Pasword { get; set; }
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
    }
}