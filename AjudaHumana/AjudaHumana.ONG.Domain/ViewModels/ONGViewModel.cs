using System;
using System.ComponentModel.DataAnnotations;

namespace AjudaHumana.ONG.Domain.ViewModels
{
    public class ONGViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome e obrigatorio.")]
        [MaxLength(256)]
        [Display(Name = "Nome:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CNPJ e obrigatorio.")]
        [MaxLength(18)]
        [Display(Name = "CNPJ:")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Breve descricao do trabalho e obrigatorio.")]
        [MaxLength(1024)]
        [Display(Name = "Breve descricao do trabalho:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Nome do Responsavel e obrigatorio.")]
        [MaxLength(256)]
        [Display(Name = "Nome do Responsavel:")]
        public string ResponsibleName { get; set; }

        [Required(ErrorMessage = "CPF do Responsavel e obrigatorio.")]
        [MaxLength(14)]
        [Display(Name = "CPF do Responsavel:")]
        public string ResponsibleCPF { get; set; }
        
        [Required(ErrorMessage = "Email do Responsavel e obrigatorio.")]
        [EmailAddress(ErrorMessage = "Email do responsavel e invalido")]
        [MaxLength(128)]
        [Display(Name = "E-mail do Responsavel:")]
        public string ResponsibleEmail { get; set; }

        [Required(ErrorMessage = "Telefone do Responsavel e obrigatorio.")]
        [MaxLength(16)]
        [Display(Name = "Telefone do Responsavel:")]
        public string ResponsiblePhoneNumber { get; set; }

        [Required(ErrorMessage = "Estado e obrigatorio.")]
        [MaxLength(2)]
        [Display(Name = "Estado:")]
        public string AddressState { get; set; }

        [Required(ErrorMessage = "Cidade e obrigatoria.")]
        [MaxLength(64)]
        [Display(Name = "Cidade:")]
        public string AddressCity { get; set; }

        [Required(ErrorMessage = "CEP e obrigatorio.")]
        [MaxLength(9)]
        [Display(Name = "CEP:")]
        public string AddressZipCode { get; set; }

        [Required(ErrorMessage = "Endereco e obrigatorio.")]
        [MaxLength(256)]
        [Display(Name = "Endereco:")]
        public string AddressStreet { get; set; }

        [Required(ErrorMessage = "Numero e obrigatorio.")]
        [Display(Name = "Numero:")]
        public int AddressNumber { get; set; }

        [MaxLength(128)]
        [Display(Name = "Complemento:")]
        public string AddressComplement { get; set; }

        [Required(ErrorMessage = "Bairro e obrigatorio.")]
        [MaxLength(128)]
        [Display(Name = "Bairro:")]
        public string AddressNeighborhood { get; set; }

        public float AddressLatitude { get; set; }
        public float AddressLongitude { get; set; }
        public string CreatedAt { get; set; }

    }
}
