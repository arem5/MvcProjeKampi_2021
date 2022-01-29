using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Maili adresini boş geçemezsiniz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu adını en az 3 karakter giriniz!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adını en az 3 karakter giriniz!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu adını en fazla 50 karakter giriniz!");
        }
    }
}
