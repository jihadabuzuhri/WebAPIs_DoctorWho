using DoctorWho.Web.Models;
using FluentValidation;

namespace DoctorWho.Web.Validators
{
    public class DoctorForUpsertionValidator : AbstractValidator<DoctorForUpsertionDto>
    {
        public DoctorForUpsertionValidator()
        {
            RuleFor(x => x.DoctorNumber).NotEmpty().WithMessage("DoctorNumber is required.");
            RuleFor(x => x.DoctorName).NotEmpty().WithMessage("DoctorName is required.");
            RuleFor(x => x.LastEpisodeDate).Empty().When(x => !x.FirstEpisodeDate.HasValue).WithMessage("LastEpisodeDate should has no value when FirstEpisodeDate has no value");
            RuleFor(x => x.LastEpisodeDate).NotEmpty().When(x => x.FirstEpisodeDate.HasValue).WithMessage("LastEpisodeDate is required if FirstEpisodeDate is present.");
            RuleFor(x => x.LastEpisodeDate).GreaterThanOrEqualTo(x => x.FirstEpisodeDate).When(x => x.FirstEpisodeDate.HasValue && x.LastEpisodeDate.HasValue).WithMessage("LastEpisodeDate must be greater than or equal to FirstEpisodeDate.");

        }
    }
}
