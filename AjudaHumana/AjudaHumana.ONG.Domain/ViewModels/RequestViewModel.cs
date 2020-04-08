using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AjudaHumana.ONG.Domain.ViewModels
{
    public class RequestViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ONGId { get; set; }

        [Required(ErrorMessage = "Breve descricão do trabalho e obrigatorio.")]
        [MaxLength(256)]
        [Display(Name = "Breve descricao do trabalho:")]
        public string Description { get; set; }
        public string Finished { get; set; }
        public string CreatedAt { get; set; }

        public List<GoalViewModel> Goals { get; set; }

        public RequestViewModel()
        {
            Goals = new List<GoalViewModel>();
        }
    }
}
