using DTOLayer.DTOs.AppUserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Surname can not be empty");
            RuleFor(x=>x.EMail).NotEmpty().WithMessage("EMail can not be empty");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("USername can not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirmation password can not be empty");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Please enter least 5 character");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Please enter max 20 character");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Passwords must be compatible");
        }
    }
}
