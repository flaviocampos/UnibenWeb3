using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Infra.CrossCutting.MvcFilters;

namespace UnibenWeb.UI.MVC.Controllers
{
    [RoutePrefix("Administrativo/ContasPagar")]
    [Route("{action=ListarContas}")]
    public class PagarContasController : Controller
    {
        private readonly IBaseAppService _baseAppService;
        private readonly IPagarContaAppService _pagarContaAppService;

        public PagarContasController(IBaseAppService baseAppService, IPagarContaAppService pagarContaAppService)
        {
            _baseAppService = baseAppService;
            _pagarContaAppService = pagarContaAppService;
        }

        // GET: PagarContas
        public ActionResult ListarContas()
        {
            return View(_baseAppService.Pesquisar<PagarContaVm>(0,999,"","PagarContas"));
        }


        public ActionResult CriarConta()
        {
            ViewBag.Pessoas = _baseAppService.ListasDeSelecao<PessoaVM>("PessoaId", "Nome", "Pessoas", " Descricao = 'Fornecedor' ", " join [dbo].[PessoaTipos] tb2 on tb2.PessoaTipoId = tb.PessoaTipoId ");
            ViewBag.CentroCustos = _baseAppService.ListasDeSelecao<CentroCustoVm>("CentroCustoId", "Descricao", "CentroCustos", "");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAjax]
        public ActionResult CriarConta(PagarContaVm pagarContaVm)
        {
            if (ModelState.IsValid)
            {
                var result = _pagarContaAppService.Adicionar(true, User.Identity.GetUserId(), pagarContaVm);
                if (!result.IsValid)
                {
                        foreach (var validationAppError in result.Erros)
                        {
                            ModelState.AddModelError(string.Empty, validationAppError.Message);
                        }

                        return Json(new { Resultado = result });                     
                }
                return Json(new { Resultado = pagarContaVm.PagarContaId }, JsonRequestBehavior.AllowGet);
            }
            else
            {

            }
            return Json(new { Validar = true });
        }
    }
}