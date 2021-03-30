using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name.Length).GreaterThan(2);
            RuleFor(c => c.BrandId).NotEmpty();
        }
    }
}
