using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NexusAsistencia.Models
{
    public class Anexo
    {
        [Key]
        public int IdAnexo { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name = "Nombre de anexo (sucursal)")]
        public string Descri { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Dirección")]
        public string DirAne { get; set; }

       [Required]
        [Display(Name = "Latitud")]
        [Range(-999.9999999999,999.999999999)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N10}")]
        public string Latitu { get; set; }

        [Required]
        [Display(Name = "Longitud")]
        [Range(-999.9999999999, 999.999999999)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N10}")]
        public string Longit { get; set; }

        [Required]
        [Display(Name = "Rango de metros de marcación")]
        public int RanMet { get; set; }

        [Display(Name = "Nota")]
        public string Nota { get; set; }

        [Required]
        public string Ruc { get; set; }

    }
}