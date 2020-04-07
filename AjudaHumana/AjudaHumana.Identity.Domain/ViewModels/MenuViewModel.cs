using System.Collections.Generic;
using AjudaHumana.Identity.Domain.Constants;

namespace AjudaHumana.Identity.Domain.ViewModels
{
    public class MenuViewModel
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Text { get; set; }
    }       
}
