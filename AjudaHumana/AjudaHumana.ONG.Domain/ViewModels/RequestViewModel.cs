using AjudaHumana.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AjudaHumana.ONG.Domain.ViewModels
{
    public class RequestViewModel : BaseViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ONGId { get; set; }
        public string ONGName { get; set; }

        [Required(ErrorMessage = "Breve descricão do trabalho e obrigatorio.")]
        [MaxLength(256)]
        [Display(Name = "Breve descricao do trabalho:")]
        public string Description { get; set; }
        public string Finished { get; set; }
        public string CreatedAt { get; set; }

        public AddressViewModel Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public List<GoalViewModel> Goals { get; set; }

        public RequestViewModel()
        {
            Goals = new List<GoalViewModel>();
        }
    }
}
