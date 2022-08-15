using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlataformaUpskill_API.Data.Models
{
    public class AvaliacaoFinal
    {
        [Key]
        public int Id { get; set; }
        public int FormandoId { get; set; }
        public Formando Formando { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public double NotaFinal { get; set; }
        public bool Validou { get; set; }

        
    }
}
