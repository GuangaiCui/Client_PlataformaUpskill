using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlataformaUpskill_API.Data.Models
{
    public class FormadorModulo
    {
        [Key]
        public int Id { get; set; }

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
