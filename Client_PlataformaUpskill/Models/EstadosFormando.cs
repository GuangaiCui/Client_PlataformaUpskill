using System;
namespace PlataformaUpskill_API.Data.Models
{
    public class EstadosFormando
    {
        public int FormandoId { get; set; }
        public Formando Formando { get; set; }
        public int ListaEstadoId { get; set; }
        public ListaEstadosFormando ListaEstadosFormando { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }

		
	}
}
