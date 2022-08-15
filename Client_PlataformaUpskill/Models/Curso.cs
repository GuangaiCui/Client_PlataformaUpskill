using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaUpskill_API.Data.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Curso precisa de uma designação.")]
        public string Nome { get; set; }
        public double DuracaoHoras { get; set; }
        public string Objetivos { get; set; }

        
    }
}