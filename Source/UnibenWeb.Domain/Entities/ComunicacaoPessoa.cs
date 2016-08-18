using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Domain.Entities
{
    [Table("ComunicacaoPessoas")]
    public class ComunicacaoPessoa
    {
        public ComunicacaoPessoa()
        {

        }
        [Key]
        public int ComunicacaoPessoaId { get; set; }
        public string Descricacao { get; set; }
        public string MotivoContato { get; set; }
        public int PessoaId { get; set; }
    }
}
