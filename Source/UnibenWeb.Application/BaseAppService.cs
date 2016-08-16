using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.Validation;
using UnibenWeb.Domain.Interfaces.Services;
using UnibenWeb.Domain.ValueObjects;
using UnibenWeb.Infra.Data.Interfaces;

namespace UnibenWeb.Application
{
    public class BaseAppService: IBaseAppService
    {
        private IUnitOfWork _uow;
        private readonly IBaseService _baseService;

        public BaseAppService()
        {
            
        }

        public BaseAppService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _uow.BeginTransaction();
        }

        public void Commit(bool doLog, string userId)
        {
            _uow.SaveChanges(doLog,userId); // commit
        }

        protected ValidationAppResult DomainToApllicationResult(ValidationResult result)
        {
            var validationAppResult = new ValidationAppResult();
            foreach (var validationError in result.Erros)
            {
                validationAppResult.Erros.Add(new ValidationAppError(validationError.Message));
            }
            validationAppResult.IsValid = result.IsValid;
            return validationAppResult;
        }

        public IEnumerable<T> Pesquisar<T>(int offsetRows, int numRows, string pesquisa, string tabela)
        {
           return _baseService.Pesquisar<T>(offsetRows, numRows, pesquisa, tabela);
        }

        public IEnumerable<T> Pesquisar<T>(int offsetRows, int numRows, string pesquisa, string tabela, string join)
        {
            return _baseService.Pesquisar<T>(offsetRows, numRows, pesquisa, tabela, join);
        }

        public SelectList ListasDeSelecao<T>(string id, string descricao, string tabela, string pesquisa)
        {
            var lista = Pesquisar<T>(0, 999, pesquisa, tabela);
            return new SelectList(lista, id, descricao);
        }

        public SelectList ListasDeSelecao<T>(string id, string descricao, string tabela, string pesquisa, string join)
        {
            var lista = Pesquisar<T>(0, 999, pesquisa, tabela, join);
            return new SelectList(lista, id, descricao, join);
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }
    }
}