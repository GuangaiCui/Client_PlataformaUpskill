using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaUpskill_API.Data.Models
{
    public class Aula
    {
        [Key]
        public int Id { get; set; }
        public string Sumario { get; set; }
        public decimal? DuracaoHoras
        {
            get
            {
                return (decimal?)(HoraFim - HoraInicio).TotalHours;
            }
        }
        //it this is neccesary,since it can be calculated
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }

        public int? TurmaId { get; set; }
        [ForeignKey("Id")]
        [ValidateNever]
        public Turma Turma { get; set; }
        public int? SalaId { get; set; }
        [ForeignKey("Id")]
        [ValidateNever]
        public Sala Sala { get; set; }
        public int? FormadorId { get; set; }
        [ForeignKey("Id")]
        [ValidateNever]
        public Formador Formador { get; set; }
        public int? ModuloId { get; set; }
        [ForeignKey("Id")]
        [ValidateNever]
        public Modulo Modulo { get; set; }
       
    }
}
