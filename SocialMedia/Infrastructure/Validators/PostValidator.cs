using FluentValidation;
using SocialMedia.Core.Dto;

namespace SocialMedia.Infrastructure.Validators
{
    public class PostValidator : AbstractValidator<PublicationDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Description)
                .NotNull()
                .Length(10, 500);

            RuleFor(post => post.Date)
                .NotNull()
                .LessThan(System.DateTime.Now);
        }
    }
}
