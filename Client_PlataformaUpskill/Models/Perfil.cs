using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaUpskill_API.Data.Models
{

    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        //public List<string> Permissoes { get; set; }
    }
}
