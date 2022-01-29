using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş bırakmayınız.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş bırakmayınız.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriğini boş bırakmayınız.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konuyu en az 3 karakter giriniz!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu için en fazla 50 karakter giriniz!");
        }
    }
}


