using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AjudaHumana.Core.ViewModels;
using Newtonsoft.Json;
using AjudaHumana.Core.Utils;
using AjudaHumana.Identity.Domain.Contracts;
using AjudaHumana.Identity.Domain.Constants;
using AjudaHumana.ONG.Application.Services;
using System.Threading.Tasks;
using System;
using AjudaHumana.ONG.Domain.ViewModels;
using AjudaHumana.Core.Factories;
using AjudaHumana.Core.Domain;

namespace AjudaHumana.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUser _user;
        private readonly IONGAppService _ongAppService;

        public HomeController(IUser user, IONGAppService ongAppService)
        {
            _user = user;
            _ongAppService = ongAppService;
        }

        [Route("")]
        public IActionResult Index()
        {
            if (_user.IsInRole(Roles.Admin))
                return RedirectToAction("Index", "Admin", new { Area = "Admin" });

            if (_user.IsInRole(Roles.ONG))
                return RedirectToAction("Index", "ONG", new { Area = "ONG" });

            var model = new HomeViewModel();

            if (TempData[TempDataConstants.ShowAlert] != null)
                model.Alert = JsonConvert.DeserializeObject<AlertViewModel>(TempData[TempDataConstants.ShowAlert].ToString());

            return View(model);
        }

        [Route("sobre-nos")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("/sou-uma-ong")]
        [HttpGet]
        public async Task<IActionResult> Upsert(Guid? id)
        {
            var ong = new ONGViewModel();

            if (!id.HasValue)
                return View(ong);

            ong = await _ongAppService.Find(id.Value);

            if (ong == null)
                return NotFound();

            return View(ong);
        }

        [Route("/sou-uma-ong")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ONGViewModel ongViewModel)
        {
            if (!ModelState.IsValid)
                return View(ongViewModel);

            if (ongViewModel.Id == Guid.Empty)
                await _ongAppService.Create(ongViewModel);
            else
                await _ongAppService.Update(ongViewModel);

            TempData[TempDataConstants.ShowAlert] = AlertFactory.NewONGCreated();

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
