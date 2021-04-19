using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace PortalEDU.Models
{
    [Index(nameof(IdAlumno), IsUnique = true)]
    public partial class Calificaciones
    {
        
        public int Id { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal? PrimerTrimestre { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal? SegundoTrimestre { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal? TercerTrimestre { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal? CuartoTrimestre { get; set; }
        [Column(TypeName = "decimal (18,4)")]
        public decimal? Promedio { get; set; }

        [NotMapped]
        public decimal? Prom => (PrimerTrimestre + SegundoTrimestre + TercerTrimestre + CuartoTrimestre) / 4;
        
        public int IdAlumno { get; set; }
        [Required]
        public DateTime Update { get; set; }
        [ForeignKey("IdAlumno")]
        public virtual Alumno Alumno { get; set; }
    }
}
