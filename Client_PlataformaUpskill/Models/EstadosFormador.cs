using System;
namespace PlataformaUpskill_API.Data.Models
{
    public class EstadosFormador
    {
        public int FormadorId { get; set; }
        public Formador Formador { get; set; }  
        public int ListaEstadoId { get; set; }
        public ListaEstadosFormador ListaEstadosFormador { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }

        
    }
}
