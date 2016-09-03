using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Domain.Entities
{
    public class BancoContaCorrente
    {
       
        public int ContaCorrenteId { get; set; }
        public string Agencia { get; set; }
        public string AgenciaDigito { get; set; }
        public string ContaCorrente { get; set; }
        public string ContaCorrenteDigito { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataTermino { get; set; }
        public virtual Banco  Banco { get; set; }
    }
}
