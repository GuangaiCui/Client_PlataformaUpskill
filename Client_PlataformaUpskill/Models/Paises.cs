using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaUpskill_API.Data.Models
{
    public class Paises
    {
        [Key]
        public string iso { get; set; }
        public string iso3 { get; set; }
        public int numcode { get; set; }
        public string nome { get; set; }
    }
}

