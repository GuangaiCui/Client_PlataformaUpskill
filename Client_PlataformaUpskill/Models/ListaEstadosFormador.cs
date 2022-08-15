using System;
using System.ComponentModel.DataAnnotations;

namespace PlataformaUpskill_API.Data.Models
{
    public class ListaEstadosFormador
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
