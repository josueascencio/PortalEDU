using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PortalEDU.Models
{
    public partial class Ciclo
    {
        //public Ciclo()
        //{
        //    CentroEducativo = new HashSet<CentroEducativo>();
        //}

        [Key]
        public int Id { get; set; }
        public int AnioAcademico { get; set; }
        [Required]
        public DateTime update { get; set; }

        //public virtual ICollection<CentroEducativo> CentroEducativos { get; set; }
    }
}
