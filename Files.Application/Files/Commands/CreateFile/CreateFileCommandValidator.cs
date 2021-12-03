using Enmeshed.BuildingBlocks.Application.Abstractions.Exceptions;
using Enmeshed.BuildingBlocks.Application.FluentValidation;
using FluentValidation;
using Enmeshed.Tooling;

namespace Files.Application.Files.Commands.CreateFile
{
    public class CreateFileCommandValidator : AbstractValidator<CreateFileCommand>
    {
        public CreateFileCommandValidator()
        {
            RuleFor(r => r.FileContent)
                .DetailedNotNull()
                .NumberOfBytes(1, 15 * 1024 * 1024); // 15 MB

            RuleFor(r => r.CipherHash)
                .DetailedNotNull()
                .NumberOfBytes(1, 128); // SHA-1024

            RuleFor(r => r.ExpiresAt)
                .DetailedNotEmpty()
                .GreaterThan(SystemTime.UtcNow).WithMessage("'{PropertyName}' must be in the future.").WithErrorCode(GenericApplicationErrors.Validation.InvalidPropertyValue().Code);

            RuleFor(m => m.Owner)
                .NotEmpty()
                .When(m => m.OwnerSignature is {Length: > 0})
                .WithMessage(m => $"{nameof(m.Owner)} and {nameof(m.OwnerSignature)} have to be provided either both or none.");

            RuleFor(m => m.OwnerSignature)
                .NotEmpty()
                .NumberOfBytes(1, 512)
                .When(m => m.Owner != default)
                .WithMessage(m => $"{nameof(m.Owner)} and {nameof(m.OwnerSignature)} have to be provided either both or none.");

            RuleFor(r => r.EncryptedProperties)
                .NumberOfBytes(0, 1 * 1024 * 1024); // 0-1 MB
        }
    }
}
