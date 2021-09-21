using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NexusAsistencia.Models.ViewModels
{
    public class BreakeVM
    {
        public int IdAsistencia { get; set; }
        public bool Breake { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? BreTie { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora inicio de Breake")]
        public DateTime? BreIni { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora fin de Breake")]
        public DateTime? BreFin { get; set; }
    }
}