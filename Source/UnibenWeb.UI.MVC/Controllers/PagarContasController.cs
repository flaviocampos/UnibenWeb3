using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Infra.CrossCutting.MvcFilters;
using UnibenWeb.UI.MVC.Models;

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

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            //var pessoas = _pessoaAppService.BuscaTodos(0, 50);
            var contaPagarParcelas = _baseAppService.Pesquisar<PagarContaParcelaVm>(0, 999, "", "PagarContaParcelas");
            IEnumerable<PagarContaParcelaVm> filteredCompanies;
            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var nameFilter = Convert.ToString(Request["sSearch_1"]);
                var addressFilter = Convert.ToString(Request["sSearch_2"]);
                var townFilter = Convert.ToString(Request["sSearch_3"]);

                //Optionally check whether the columns are searchable at all 
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isAddressSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isTownSearchable = Convert.ToBoolean(Request["bSearchable_3"]);

                filteredCompanies = _baseAppService.Pesquisar<PagarContaParcelaVm>(0, 999, "", "PagarContaParcelas")
                   .Where(c => isNameSearchable && c.PagarContaParcelaId.ToString().ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isAddressSearchable && c.ValorParcela.ToString().ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isTownSearchable && c.DataVencimento.ToString().ToLower().Contains(param.sSearch.ToLower()));
            }
            else
            {
                filteredCompanies = contaPagarParcelas;
            }

            var isNameSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isAddressSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isTownSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<PagarContaParcelaVm, string> orderingFunction = (c => sortColumnIndex == 1 && isNameSortable ? c.PagarContaParcelaId.ToString() :
                                                           sortColumnIndex == 2 && isAddressSortable ? c.ValorParcela.ToString() :
                                                           sortColumnIndex == 3 && isTownSortable ? c.DataVencimento.ToString() :
                                                           "");

            var sortDirection = Request["sSortDir_0"];
            if (sortDirection == "asc")
                filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
            else
                filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);

            var displayedCompanies = filteredCompanies.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCompanies select new[] { Convert.ToString(c.PagarContaParcelaId), c.PagarContaParcelaId.ToString(), c.ValorParcela.ToString(), c.DataVencimento.ToString()};
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = contaPagarParcelas.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }


    }
}