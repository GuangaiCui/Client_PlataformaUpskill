using System.ComponentModel.DataAnnotations;

namespace PlataformaUpskill_API.Data.Models
{
    public class Sala
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int LocalId { get; set; }
        public Local Local { get; set; }

    }
}
