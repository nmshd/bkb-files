using Enmeshed.BuildingBlocks.Application.Abstractions.Exceptions;

namespace Files.Application;

public static class ApplicationErrors
{
    public static ApplicationError FileHasExpired()
    {
        return new ApplicationError("error.platform.validation.file.fileExpired", "The file has expired.");
    }

    public static class Files
    {
        public static class Create
        {
            public static ApplicationError ContentCannotBeEmpty()
            {
                return new ApplicationError("error.platform.validation.file.contentCannotBeNull", "The content of a file cannot be empty.");
            }

            public static ApplicationError InvalidContentSize()
            {
                return new ApplicationError("error.platform.validation.file.invalidContentSize", "The size of the content is invalid.");
            }

            public static ApplicationError CipherHashCannotBeEmpty()
            {
                return new ApplicationError("error.platform.validation.file.cipherHashCannotBeNull", "The cipherHash of a file cannot be empty.");
            }

            public static ApplicationError InvalidCipherHashSize()
            {
                return new ApplicationError("error.platform.validation.file.invalidCipherHashSize", "The size of the cipherHash is invalid.");
            }
        }
    }
}
