using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NexusAsistencia.Models
{
    public class Asistencia
    {
        [Key]
        public int IdAsistencia { get; set; }

       
        [Display(Name ="Empresa")]
        public string Ruc { get; set; }

       
        [Display(Name ="Local Anexo (sucursal)")]
        public int IdAnexo { get; set; }

        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="Fecha")]
        public DateTime? Fecha { get; set; }

        [DataType(DataType.Time)]
        [Display(Name ="Hora de entrada registrada")]
        public TimeSpan? HorEnt { get; set; }

        /*Breake*/
        public bool Breake { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? BreTie { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora inicio de Breake")]
        public TimeSpan? BreIni { get; set; }

        [DataType(DataType.Time)]
        [Display(Name ="Hora fin de Breake")]
        public TimeSpan? BreFin { get; set; }

        /*Salida*/
        [DataType(DataType.Time)]
        [Display(Name ="Hora de salida")]
        public TimeSpan? HorSal { get; set; }

        //[Display(Name ="Salida Latitud")]
        //public string SalLat { get; set; }
        //public string SalLon { get; set; }

        public virtual Empresa empresa { get; set; }
        public virtual Anexo anexo { get; set; }

        public Asistencia() 
        {
            
        }

        
    }
}