namespace PlataformaUpskill_API.Data.Models
{
    public class FormadorModuloTurma
    {
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public int FormadorModuloId { get; set; }
        public FormadorModulo FormadorModulo { get; set; }

    }
}
