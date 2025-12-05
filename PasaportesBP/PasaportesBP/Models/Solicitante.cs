using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasaportesBP.Models
{
    [Table("BP_Solicitante")]
    public class Solicitante
    {
        [Key]
        public int SolicitanteID { get; set; }

        [Required]
        [StringLength(20)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(200)]
        public string? Direccion { get; set; }

        [StringLength(20)]
        public string? Telefono { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
}
