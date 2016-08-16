using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnibenWeb.Application.Interface
{
    public interface IBaseAppService : IDisposable
    {
        IEnumerable<T> Pesquisar<T>(int offsetRows, int numRows, string pesquisa, string tabela);
        SelectList ListasDeSelecao<T>(string id, string descricao, string tabela, string pesquisa);
        SelectList ListasDeSelecao<T>(string id, string descricao, string tabela, string pesquisa, string join);
    }
}