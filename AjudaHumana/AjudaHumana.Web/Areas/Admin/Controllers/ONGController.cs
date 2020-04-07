using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AjudaHumana.Core.Factories;
using AjudaHumana.Core.Utils;
using AjudaHumana.Core.ViewModels;
using AjudaHumana.Identity.Domain.Contracts;
using AjudaHumana.ONG.Application.Services;
using AjudaHumana.ONG.Domain.ViewModels;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjudaHumana.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("ong")]
    //[Authorize]
    public class ONGController : Controller
    {
        private readonly IONGAppService _ongAppService;
        private readonly IUserAppService _userAppService;
        private readonly IEmailSender _emailSender;

        public ONGController(IONGAppService ongAppService,
                             IUserAppService userAppService,
                             IEmailSender emailSender)
        {
            _ongAppService = ongAppService;
            _userAppService = userAppService;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            if (TempData[TempDataConstants.ShowAlert] != null)
                model.Alert = JsonConvert.DeserializeObject<AlertViewModel>(TempData[TempDataConstants.ShowAlert].ToString());

            return View(model);
        }

        //[Route("revisar")]
        [HttpGet]
        public async Task<IActionResult> Review(Guid id)
        {
            var ong = await _ongAppService.Find(id);

            if (ong == null)
                return NotFound();

            return View(ong);
        }

        //[Route("revisar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(ONGViewModel ongViewModel, bool approved)
        {
            ongViewModel.Approved = approved;
            await _ongAppService.Update(ongViewModel);

            if (approved)
            {
                var user = await _userAppService.CreateONGUser(ongViewModel.ResponsibleEmail);
                var code = await _userAppService.GenerateConfirmationEmailCode(user.User);

                var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.User.Id, code },
                        protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(ongViewModel.ResponsibleEmail, "Confirm your email",
                    $@"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.
                    <p>Nova senha: {user.TempPassword}");
            }

            TempData[TempDataConstants.ShowAlert] = approved ? AlertFactory.NewONGApproved() : AlertFactory.NewONGReproved();

            return RedirectToAction("Index", new { area = "Admin" });
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ongs = await _ongAppService.GetAll(w => !w.Approved.HasValue);
            return Json(new { data = ongs });
        }

        #endregion
    }
}