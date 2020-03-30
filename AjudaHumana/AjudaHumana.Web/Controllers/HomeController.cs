using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AjudaHumana.Core.ViewModels;
using Newtonsoft.Json;
using AjudaHumana.Core.Utils;

namespace AjudaHumana.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
