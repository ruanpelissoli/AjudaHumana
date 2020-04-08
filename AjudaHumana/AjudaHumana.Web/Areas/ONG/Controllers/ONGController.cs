using System;
using System.Threading.Tasks;
using AjudaHumana.Core.Factories;
using AjudaHumana.Core.Utils;
using AjudaHumana.Identity.Domain.Constants;
using AjudaHumana.ONG.Application.Services;
using AjudaHumana.ONG.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [Route("pedido")]
        [HttpGet]
        public async Task<IActionResult> Upsert(Guid? id)
        {
            var request = new RequestViewModel();

            if (!id.HasValue)
                return View(request);

            request = await _ongAppService.GetRequest(id.Value);

            if (request == null)
                return NotFound();

            return View(request);
        }

        [Route("pedido")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Guid? id, RequestViewModel requestViewModel)
        {
            var request = await _ongAppService.GetRequest(id.Value);

            TempData[TempDataConstants.ShowAlert] = AlertFactory.NewONGApproved();

            return RedirectToAction("Index", new { area = "ONG" });
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
            return Json(new { data = requests });
        }

        #endregion
    }
}