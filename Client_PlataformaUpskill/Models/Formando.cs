using System.Collections.Generic;

namespace PlataformaUpskill_API.Data.Models
{
    public class Formando
    {
        [Key]
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public string IBAN { get; set; }
        public bool Bolsa { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado? Estado { get; set; }       
        public int turmaId { get; set; }
        public virtual Turma Turma { get; set; }


        /*
        public Dictionary<int, AvaliacaoModular> DictAvaliacaoModular { get; set; }

		public Formando() { }

		public Formando(Formando formando)
		{
            
            this.Id = formando.Id;
            this.Nome = formando.Nome;
            this.Turma = formando.Turma;
            this.DictAvaliacaoModular = new Dictionary<int, AvaliacaoModular>(formando.DictAvaliacaoModular);
        }
        */
    }
}