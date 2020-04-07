using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AjudaHumana.ONG.Data;
using AjudaHumana.ONG.Domain;
using AjudaHumana.ONG.Application.Services;
using AjudaHumana.ONG.Domain.ViewModels;
using AjudaHumana.Core.ViewModels;
using Newtonsoft.Json;
using AjudaHumana.Core.Utils;
using AjudaHumana.Core.Factories;

namespace AjudaHumana.Web.Controllers
{
    [Route("ong")]
    public class ONGController : Controller
    {
        private readonly IONGAppService _ongAppService;

        public ONGController(IONGAppService ongAppService)
        {
            _ongAppService = ongAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("sou-uma-ong")]
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

        [Route("sou-uma-ong")]
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
    }
}
