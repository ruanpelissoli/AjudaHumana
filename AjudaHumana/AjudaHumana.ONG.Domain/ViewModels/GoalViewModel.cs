using System;
using System.ComponentModel.DataAnnotations;

namespace AjudaHumana.ONG.Domain.ViewModels
{
    public class GoalViewModel
    {
        [Key]
        public Guid GoalId { get; set; }

        [Required(ErrorMessage = "Descrição da Meta é obrigatória.")]
        [MaxLength(128)]
        [Display(Name = "Descrição da Meta:")]
        public string ItemName { get; set; }

        [Display(Name = "Atual:")]
        public int CurrentGoal { get; set; }

        [Required(ErrorMessage = "Meta é obrigatória.")]
        [Display(Name = "Meta:")]
        public int FinishedGoal { get; set; }

        public bool Finished { get; set; }
        public Guid RequestId { get; set; }
    }
}
