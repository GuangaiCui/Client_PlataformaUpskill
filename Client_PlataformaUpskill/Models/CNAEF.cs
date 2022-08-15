using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaUpskill_API.Data.Models
{
    public class CNAEF
    {
        [Key]
        public string CodigoCNAEF { get; set; }
        public string AreaFormacao { get; set; }
    }
}
