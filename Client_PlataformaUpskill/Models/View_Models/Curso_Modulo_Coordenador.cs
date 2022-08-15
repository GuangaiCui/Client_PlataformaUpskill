namespace Client_PlataformaUpskill.Models.View_Models
{
    public class Curso_Modulo_Coordenador
    {
        public Curso curso { get; set; }
        public List<CursoCoordenador>? CursoCoordenador { get; set; }
        public List<CursoModulo>? CursoModulo { get; set; }

        public List<CursoCoordenador>? Coordenadores { get; set; }
        public List<CursoModulo>? Modulos { get; set; }
    }
}
