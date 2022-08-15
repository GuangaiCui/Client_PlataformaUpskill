namespace PlataformaUpskill_API.Data.Models
{
    public class CursoCoordenador
    {
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
