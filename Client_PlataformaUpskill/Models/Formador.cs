using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlataformaUpskill_API.Data.Models
{
    public class Formador
    {
        [Key]
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public bool CCP { get; set; }
        public bool DocenteEnsSuperior { get; set; }
		public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
        
    }
}