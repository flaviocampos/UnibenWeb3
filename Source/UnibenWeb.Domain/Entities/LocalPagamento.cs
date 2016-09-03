namespace UnibenWeb.Domain.Entities
{
    public class LocalPagamento
    {
        public int LocalPagamentoId { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
        public bool Ativo { get; set; }
    }
}