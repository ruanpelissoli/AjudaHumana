using System;
using System.Collections.Generic;

namespace AjudaHumana.ONG.Domain.ViewModels
{
    public class RequestViewModel
    {
        public Guid Id { get; set; }
        public Guid ONGId { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public string CreatedAt { get; set; }

        public ICollection<Goal> Goals { get; set; }
    }
}
