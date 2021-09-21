using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NexusAsistencia.Models
{
    public class Empresa
    {
        [Key]
        [StringLength(11)]
        [Required]
        [MinLength(11)]
        [RegularExpression("(^[0-9]+$)")]
        [Display(Name ="RUC")]
        public string Ruc { get; set; }

        [MaxLength(50)]
        [Required]
        [Display(Name ="Razón social")]
        public string RazSoc { get; set; }

        [MaxLength(100)]
        [Display(Name = "Dirección")]
        public string DirEmp { get; set; }

        [MaxLength(20)]
        [Display(Name = "Persona de Contacto")]
        public string Contac { get; set; }

        [MaxLength(20)]
        [Display(Name = "Celular")]
        public string CelCon { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Anexo> Anexos { get; set; }

        public Empresa() 
        {
            this.Anexos = new HashSet<Anexo>();
        }
    }
}