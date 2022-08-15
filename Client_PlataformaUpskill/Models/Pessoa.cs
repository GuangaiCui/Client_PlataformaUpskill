using System;
using System.ComponentModel.DataAnnotations;

namespace PlataformaUpskill_API.Data.Models
{
    public class Pessoa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Email { get; set; }
		public string? Password { get; set; }

        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }
		public string Sexo { get; set; }
        public string NIF { get; set; }
		public string CC { get; set; }
		public string ContactoTelemovel { get; set; }
		public string ContactoTelefone { get; set; }
        public string Morada { get; set; }
        public string CP { get; set; }
        public string CodigoCNAEF { get; set; }
        [ForeignKey("CodigoCNAEF")]
        [ValidateNever]
        public virtual CNAEF CNAEF { get; set; }
        public int HabilitacoesId { get; set; }
        public virtual Habilitacoes Habilitacoes { get; set; }
        public string Nacionalidade { get; set; }
		public byte[]? Foto { get; set; }
        public byte[]? CV { get; set; }

        
        public int? PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        //public string Funcao { get; set; }
        //since one user pessoa only has one funcao, can we delete the Pessoal model
        //and change the funcao to funcaoesId
    }
}
