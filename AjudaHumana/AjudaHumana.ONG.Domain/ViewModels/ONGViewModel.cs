using System;
using System.ComponentModel.DataAnnotations;

namespace AjudaHumana.ONG.Domain.ViewModels
{
    public class ONGViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(256)]
        [Display(Name = "Nome:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CNPJ é obrigatório.")]
        [MaxLength(18)]
        [Display(Name = "CNPJ:")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Breve descrição do trabalho é obrigatório.")]
        [MaxLength(1024)]
        [Display(Name = "Breve descrição do trabalho:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Nome do Responsável é obrigatório.")]
        [MaxLength(256)]
        [Display(Name = "Nome do Responsável:")]
        public string ResponsibleName { get; set; }

        [Required(ErrorMessage = "CPF do Responsável é obrigatório.")]
        [MaxLength(14)]
        [Display(Name = "CPF do Responsável:")]
        public string ResponsibleCPF { get; set; }
        
        [Required(ErrorMessage = "E-mail do Responsável é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail do Responsável é inválido")]
        [MaxLength(128)]
        [Display(Name = "E-mail do Responsável:")]
        public string ResponsibleEmail { get; set; }

        [Required(ErrorMessage = "Telefone do Responsável é obrigatório.")]
        [MaxLength(16)]
        [Display(Name = "Telefone do Responsável:")]
        public string ResponsiblePhoneNumber { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório.")]
        [MaxLength(2)]
        [Display(Name = "Estado:")]
        public string AddressState { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório.")]
        [MaxLength(64)]
        [Display(Name = "Cidade:")]
        public string AddressCity { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório.")]
        [MaxLength(9)]
        [Display(Name = "CEP:")]
        public string AddressZipCode { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        [MaxLength(256)]
        [Display(Name = "Endereço:")]
        public string AddressStreet { get; set; }

        [Required(ErrorMessage = "Número é obrigatório.")]
        [Display(Name = "Número:")]
        public int AddressNumber { get; set; }

        [MaxLength(128)]
        [Display(Name = "Complemento:")]
        public string AddressComplement { get; set; }

        [Required(ErrorMessage = "Bairro é obrigatório.")]
        [MaxLength(128)]
        [Display(Name = "Bairro:")]
        public string AddressNeighborhood { get; set; }

        public float AddressLatitude { get; set; }
        public float AddressLongitude { get; set; }
        public string CreatedAt { get; set; }
        public string Approved { get; set; }

    }
}
