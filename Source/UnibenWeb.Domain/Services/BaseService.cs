using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;
using UnibenWeb.Domain.Interfaces.Services;

namespace UnibenWeb.Domain.Services
{
    public class BaseService:IBaseService
    {
         private readonly IBaseReadOnlyRepository _baseReadOnlyRepository;

        public BaseService(IBaseReadOnlyRepository baseReadOnlyRepository)
        {
            _baseReadOnlyRepository = baseReadOnlyRepository;
        }

        public void Dispose()
        {
            // dispose repo
        }

        public IEnumerable<T> Pesquisar<T>(int offsetRows, int numRows, string pesquisa, string tabela)
        {
           return _baseReadOnlyRepository.Pesquisar<T>(offsetRows, numRows, pesquisa, tabela);
        }

        public IEnumerable<T> Pesquisar<T>(int offsetRows, int numRows, string pesquisa, string tabela, string join)
        {
            return _baseReadOnlyRepository.PesquisarJoinWhere<T>(offsetRows, numRows, pesquisa, tabela, join);
        }

    }
}