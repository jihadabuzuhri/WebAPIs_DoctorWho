using DoctorWho.Db;
using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class EpisodeForCreationValidator : AbstractValidator<EpisodeForCreationDto>
    {
        public EpisodeForCreationValidator() 
        {

            RuleFor(x => x.AuthorId)
               .NotEmpty()
               .WithMessage("Author ID is required.");

            RuleFor(x => x.DoctorId)
                .NotEmpty()
                .WithMessage("Doctor ID is required.");

            RuleFor(x => x.SeriesNumber.ToString())
                .Length(10)
                .WithMessage("Series number should be 10 characters long.");

            /*
            RuleFor(x => x.SeriesNumber)
                .NotEmpty()
                .Must(s => s.ToString().Length == 10)
                .WithMessage("Series number should be 10 characters long.");
            */


            RuleFor(x => x.EpisodeNumber)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Episode number should be greater than 0.");

        }
    }
}
