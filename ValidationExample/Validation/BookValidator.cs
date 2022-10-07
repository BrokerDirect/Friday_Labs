using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using ValidationExample.Enitites;

namespace ValidationExample.Validation
{
    internal class BookValidator : AbstractValidator<Book>
    {
       public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(x => x.Title + "The Title of this book is empty");
            
            RuleForEach(x => x.Reviews).NotEmpty()
                .WithMessage("No Reviews")
                .WithSeverity(Severity.Info)
                .WithErrorCode("1234567");
            
            RuleFor(X => X.Author)
                .NotNull().WithMessage("No Author Associated with book")
                .NotEmpty().WithMessage("This book has an author with an empty forename").WithSeverity(Severity.Error)
                .Must(author => CheckAuthorIsntJeff(author)).WithMessage("No Jeffs allowed");


        }

        //Random Custom Validator
        public bool CheckAuthorIsntJeff(Author author)
        {
            if(author ==null)
                return true;
            

                if (author.Forename.ToLower() == "jeff")
                    return false;

                return true;

        }
    }
}
