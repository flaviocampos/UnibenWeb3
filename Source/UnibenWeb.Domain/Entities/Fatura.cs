using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Domain.Entities
{
    public class Fatura
    {
        public int FaturaId { get; set; }
        public int FornecedorId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataAcolhimentoFatura { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal  ValorFaturaOriginal { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal valorMulta { get; set; }
        public decimal valorDesconto { get; set; }
        public DateTime DataLimiteDesconto { get; set; }
        public DateTime DataPrevisaoPagamento { get; set; }
        public DateTime DataRealPagmento { get; set; }
        public decimal ValorRealPago { get; set; }
        public string NumeroFaturaFornecedor { get; set; }
        public string Controle { get; set; }
        public string Obs { get; set; }
        public int FaturaIdNegociacao { get; set; }
        public DateTime DataNegociacao { get; set; }
        public string NumeroCheque { get; set; }



        public virtual ContaContabil ContaContabil { get; set; }
        public virtual CentroCusto  CentroCusto { get; set; }
        public virtual BancoContaCorrente BancoContaCorrente { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        public virtual LocalPagamento LocalPagamento { get; set; }
        public virtual TipoLancamento TipoLancamento { get; set; }
        public virtual Pessoa Fornecedor { get; set; }  
    }
}
