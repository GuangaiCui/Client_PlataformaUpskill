using System.ComponentModel.DataAnnotations;

namespace PlataformaUpskill_API.Data.Models
{
    public class CursoModulo
    {
        
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int ModuloId { get; set; }
        public Modulo Modulo { get; set; }
        public int Ordem { get; set; }

    }
}
