using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Calificaciones
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal PrimerTrimestre { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal SegundoTrimestre { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal TercerTrimestre { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal CuartoTrimestre { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal Promedio { get; set; }
        public int IdAlumno { get; set; }
        [Required]
        public DateTime update { get; set; }

        public virtual Alumno IdAlumnoNavigation { get; set; }
    }
}
