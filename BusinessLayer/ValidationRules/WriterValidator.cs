using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş bırakmayınız.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş bırakmayınız.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Yazar soyadını en az 2 karakter giriniz .");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adını en az 2 karakter giriniz .");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmını boş bırakmayınız.");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Hakkında kısmını en fazla 100 karakter giriniz .");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmını boş bırakmayınız.");
            RuleFor(x => x.WriterTitle).MaximumLength(25).WithMessage("Ünvan hakkında en fazla 25 karakter giriniz .");
        }
    }
}
