namespace Client_PlataformaUpskill.Models.View_Models
{
    public class Formando_Details
    {
        public Formando Formando { get; set; }

        public decimal? FaltasJustificadas { get; set; }
        public decimal? FaltasInjustificadas { get; set; }

        public List<AvaliacaoModular> AvaliacaoModular { get; set; }
        public AvaliacaoFinal AvaliacaoFinal { get; set; }

        public Turma Turma { get; set; }
        public List<CursoModulo> CursoModulo { get; set; }

    }
}
