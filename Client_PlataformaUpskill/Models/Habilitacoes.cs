using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaUpskill_API.Data.Models
{
	public class Habilitacoes
	{
		[Key]
		public int Id { get; set; }
		public string HabilitacoesLiterarias { get; set; }
	}
}
