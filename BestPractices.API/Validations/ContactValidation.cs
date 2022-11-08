using BestPractices.API.Models;
using FluentValidation;

namespace BestPractices.API.Validations
{
    public class ContactValidation : AbstractValidator<ContactDVO>
    {

        public ContactValidation()
        {
            RuleFor(x => x.Id).LessThan(100).WithMessage("Id 100' den büyük olamaz");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim soyisim boş olamaz");

        }
    }
}
