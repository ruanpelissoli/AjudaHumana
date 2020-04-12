using System.Collections.Generic;

namespace AjudaHumana.Core.ViewModels
{
    public class HomeViewModel<T> : BaseViewModel
    {
        public IEnumerable<T> List { get; set; }
    }
}
