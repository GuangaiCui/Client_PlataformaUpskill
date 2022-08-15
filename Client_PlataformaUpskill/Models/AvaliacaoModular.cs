using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlataformaUpskill_API.Data.Models
{
    public class AvaliacaoModular
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int FormandoId { get; set; }
        public virtual Formando Formando { get; set; }

        public double NotaFinal { get; set; }
        public string Comentarios { get; set; }
        
        public int ModuloId { get; set; }
        public Modulo Modulo { get; set; }

        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public bool Validou { get; set; }
        public int FormadorId { get; set; }
        public Formador Formador { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }
       
    }
}