using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AjudaHumana.Core.Factories;
using AjudaHumana.Core.Utils;
using AjudaHumana.Core.ViewModels;
using AjudaHumana.Identity.Domain.Constants;
using AjudaHumana.Identity.Domain.Contracts;
using AjudaHumana.ONG.Application.Services;
using AjudaHumana.ONG.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjudaHumana.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly IONGAppService _ongAppService;
        private readonly IUserAppService _userAppService;
        private readonly IEmailSender _emailSender;

        public AdminController(IONGAppService ongAppService,
                             IUserAppService userAppService,
                             IEmailSender emailSender)
        {
            _ongAppService = ongAppService;
            _userAppService = userAppService;
            _emailSender = emailSender;
        }

        [Route("")]
        public IActionResult Index()
        {
            var model = new HomeViewModel();

            if (TempData[TempDataConstants.ShowAlert] != null)
                model.Alert = JsonConvert.DeserializeObject<AlertViewModel>(TempData[TempDataConstants.ShowAlert].ToString());

            return View(model);
        }

        [Route("revisar/{id}")]
        [HttpGet]
        public async Task<IActionResult> Review([FromRoute] Guid id)
        {
            var ong = await _ongAppService.Find(id);

            if (ong == null)
                return NotFound();

            return View(ong);
        }

        [Route("revisar/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review([FromRoute] Guid id, bool approved)
        {
            var ong = await _ongAppService.Find(id);

            ong.Approved = approved ? "Sim" : "Não";
            await _ongAppService.Update(ong);

            if (approved)
            {
                var user = await _userAppService.CreateONGUser(ong.ResponsibleEmail);

                await _ongAppService.UpdateUserId(ong, Guid.Parse(user.User.Id));
                
                await _emailSender.SendEmailAsync(ong.ResponsibleEmail, ong.Name,
                    $@"<p>Nova senha: {user.TempPassword} <br />
                       Será alterada no primeiro logi.</p>");
            }

            TempData[TempDataConstants.ShowAlert] = approved ? AlertFactory.NewONGApproved() : AlertFactory.NewONGReproved();

            return RedirectToAction("Index", new { area = "Admin" });
        }

        #region API CALLS

        [HttpGet("ongs")]
        public async Task<IActionResult> GetAll()
        {
            var ongs = await _ongAppService.GetAll(w => !w.Approved.HasValue);
            ongs = ongs.Select(s => { s.Approved = s.Approved == "True" ? "Sim" : "Não"; return s; });
            return Json(new { data = ongs });
        }

        #endregion
    }
}