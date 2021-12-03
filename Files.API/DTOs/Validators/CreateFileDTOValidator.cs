using Enmeshed.BuildingBlocks.Application.FluentValidation;
using FluentValidation;

namespace Files.API.DTOs.Validators
{
    public class CreateFileDTOValidator : AbstractValidator<CreateFileDTO>
    {
        private const string MIME_TYPE = "application/octet-stream";

        public CreateFileDTOValidator()
        {
            CascadeMode = CascadeMode.Stop;


            RuleFor(f => f.Content).NotNull();
            RuleFor(f => f.Content.ContentType).In(MIME_TYPE).WithName("Content Type").WithMessage($"The file must have the MIME type {MIME_TYPE}.");
            RuleFor(f => f.Content.Length).InclusiveBetween(1, 10 * 1024 * 1024).WithName("Content Length");
        }
    }
}
