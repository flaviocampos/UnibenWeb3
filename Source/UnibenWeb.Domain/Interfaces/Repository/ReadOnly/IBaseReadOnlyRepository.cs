using System.Collections.Generic;

namespace UnibenWeb.Domain.Interfaces.Repository.ReadOnly
{
    public interface IBaseReadOnlyRepository
    {
        IEnumerable<T> Pesquisar<T>(int offsetRows, int numRows, string pesquisa, string tabela);
        IEnumerable<T> PesquisarJoinWhere<T>(int offsetRows, int numRows, string pesquisa, string tabela, string join);
    }
}