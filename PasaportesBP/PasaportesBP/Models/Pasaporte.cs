using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasaportesBP.Models
{
    [Table("BP_Pasaporte")]
    public class Pasaporte
    {
        [Key]
        public int PasaporteID { get; set; }

        [Required]
        [StringLength(20)]
        public string NumeroPasaporte { get; set; } = string.Empty;

        [Required]
        public int SolicitanteID { get; set; }

        [ForeignKey(nameof(SolicitanteID))]
        public Solicitante? Solicitante { get; set; }

        public DateTime FechaSolicitud { get; set; } = DateTime.Now;

        public DateTime? FechaAprobacion { get; set; }

        public DateTime? FechaEntrega { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = "Solicitado";
    }
}
