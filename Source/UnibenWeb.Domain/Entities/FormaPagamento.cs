namespace UnibenWeb.Domain.Entities
{
    public class FormaPagamento
    {
        public int FormaPagamentoId { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
        public bool Ativo { get; set; }
    }
}