using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class AutomovilValidator : AbstractValidator<Automovil>
    {
        public AutomovilValidator()
        {
            RuleFor(a => a.Marca)
            .NotEmpty().WithMessage("La marca es obligatoria.")
            .MaximumLength(15).WithMessage("La marca no puede superar los 15 caracteres.");
           
            RuleFor(a => a.Modelo)
            .NotEmpty().WithMessage("El modelo es obligatorio.")
            .MaximumLength(10).WithMessage("El modelo no puede superar los 10 caracteres.");
           
            RuleFor(a => a.Fabricacion)
            .InclusiveBetween(1900, DateTime.Now.Year + 1)
            .WithMessage("El año debe estar entre 1900 y el próximo año.");
            RuleFor(a => a.Color)
            .NotEmpty().WithMessage("El color es obligatorio.")
            .MaximumLength(10).WithMessage("El color no puede superar los 10 caracteres.");
        }
    }

}
