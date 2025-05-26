using DTOLayer.DTOs.ContactDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation.ContactUs
{
    public class SendContactUsValidatior:AbstractValidator<SendMessageDto>
    {
       public SendContactUsValidatior() {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Can not be null");
            RuleFor(x=>x.MessageBody).NotEmpty().WithMessage("Can not be null");
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Can not be null");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Can not be null");
            RuleFor(x => x.Email).MinimumLength(5).WithMessage("Please enter more than 5 chracter");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Please enter more than 5 chracter");
        }
    }
}
