using AjudaHumana.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaHumana.ONG.Application.Commands
{
    public class CreateONGCommand : Command
    {

        public CreateONGCommand()
        {

        }

        public override bool IsValid()
        {
            ValidationResult = new CreateONGCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CreateONGCommandValidation : AbstractValidator<CreateONGCommand>
    {
    }
}
