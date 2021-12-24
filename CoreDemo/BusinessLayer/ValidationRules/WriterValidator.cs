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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez")
                .Matches(@"[A-Z]+").WithMessage("Şifre en az bir adet büyük harf içermelidir.")
                .Matches(@"[a-z]+").WithMessage("Şifre en az bir adet küçük harf içermelidir")
                .Matches(@"[0-9]+").WithMessage("Şifre en az bir rakam içermelidir.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın");
            RuleFor(x => x.WriterConfirmPassword).Equal(x => x.WriterPassword).WithMessage("Girilen şifreler birbiri ile tutarlı olmalıdır");
        }
    }
}
