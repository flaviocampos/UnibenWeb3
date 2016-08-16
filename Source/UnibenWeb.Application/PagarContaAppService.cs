using AutoMapper;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.Validation;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Services;

namespace UnibenWeb.Application
{
    public class PagarContaAppService : BaseAppService, IPagarContaAppService
    {
        private readonly IPagarContaService _pagarContaService;
        private readonly IBaseService _baseService;

        public PagarContaAppService(IPagarContaService pagarContaService, IBaseService baseService)
        {
            _pagarContaService = pagarContaService;
            _baseService = baseService;
        }

        public ValidationAppResult Adicionar(bool doLog, string userId, PagarContaVm pagarContaVm)
        {
            var pagarConta = Mapper.Map<PagarContaVm, PagarConta>(pagarContaVm);
            BeginTransaction();
            var result =  _pagarContaService.Adicionar(pagarConta);
            if (!result.IsValid) { return DomainToApllicationResult(result); }
            Commit(doLog, userId);
            pagarContaVm.PagarContaId = pagarConta.PagarContaId;
            return DomainToApllicationResult(result);
        }
    }
}
