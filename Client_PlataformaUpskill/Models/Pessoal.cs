namespace PlataformaUpskill_API.Data.Models
{
	public class Pessoal
	{
		[Key]
		public int PessoaId { get; set; }

		public virtual Pessoa Pessoa { get; set; }
		public int FuncaoId { get; set; }
		public virtual Funcoes Funcoes { get; set; }
	}
}
