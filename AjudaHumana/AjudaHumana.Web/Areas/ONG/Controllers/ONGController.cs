using System;
using System.Linq;
using System.Threading.Tasks;
using AjudaHumana.Core.Factories;
using AjudaHumana.Core.Utils;
using AjudaHumana.Core.ViewModels;
using AjudaHumana.Identity.Domain.Constants;
using AjudaHumana.ONG.Application.Services;
using AjudaHumana.ONG.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjudaHumana.Web.Areas.ONG.Controllers
{
    [Area("ONG")]
    [Route("ong")]
    [Authorize(Roles = Roles.ONG)]
    public class ONGController : Controller
    {
        private readonly IONGAppService _ongAppService;

        public ONGController(IONGAppService ongAppService)
        {
            _ongAppService = ongAppService;
        }

        [Route("")]
        public IActionResult Index()
        {
            var model = new HomeViewModel();

            if (TempData[TempDataConstants.ShowAlert] != null)
            {
                model.Alert = JsonConvert.DeserializeObject<AlertViewModel>(TempData[TempDataConstants.ShowAlert].ToString());
            }

            return View(model);
        }

        [Route("pedido")]
        [HttpGet]
        public async Task<IActionResult> Upsert(Guid? id)
        {
            var requestViewModel = new RequestViewModel();

            if (!id.HasValue || id.Value == Guid.Empty)
            {
                requestViewModel.Goals.Add(new GoalViewModel { GoalId = Guid.NewGuid() });
                return View(requestViewModel);
            }

            requestViewModel = await _ongAppService.GetRequest(id.Value);

            if (requestViewModel == null)
                return NotFound();

            return View(requestViewModel);
        }

        [Route("pedido")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(RequestViewModel requestViewModel, Guid? id)
        {
            if (!ModelState.IsValid)
                return View(requestViewModel);

            if (!id.HasValue || id.Value == Guid.Empty)
            {
                await _ongAppService.CreateRequest(requestViewModel);
                TempData[TempDataConstants.ShowAlert] = AlertFactory.NewRequestCreated();
            }
            else
            {
                await _ongAppService.UpdateRequest(requestViewModel);
                TempData[TempDataConstants.ShowAlert] = AlertFactory.RequestEdited();
            }           

            return RedirectToAction("Index", new { area = "ONG" });
        }

        [Route("nova-meta")]
        [HttpPost]
        public IActionResult AddGoal(RequestViewModel requestViewModel)
        {
            ModelState.Clear();

            requestViewModel.Goals.Add(new GoalViewModel { GoalId = Guid.NewGuid() });
            return View("Upsert", requestViewModel);
        }

        [Route("remover-meta")]
        [HttpPost]
        public IActionResult RemoveGoal(RequestViewModel requestViewModel, Guid goalId)
        {
            ModelState.Clear();

            requestViewModel.Goals = requestViewModel.Goals.Where(w => w.GoalId != goalId).ToList();
            return View("Upsert", requestViewModel);
        }

        [Route("info")]
        [HttpGet]
        public async Task<IActionResult> Info()
        {
            return View();
        }

        #region API CALLS

        [HttpGet("pedidos")]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _ongAppService.GetRequests();
            requests = requests.Select(s => {s.Finished = s.Finished == "True" ? "Sim" : "Não"; return s; });
            return Json(new { data = requests });
        }

        #endregion
    }
}