namespace UnibenWeb.Domain.Entities
{
    public class TipoLancamento
    {
        public int TipoLancamentoId { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
        public bool Ativo { get; set; }
    }
}