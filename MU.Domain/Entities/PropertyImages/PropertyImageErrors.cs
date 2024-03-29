﻿using ErrorOr;

namespace MU.Domain.Entities.PropertyImages
{
    public static class PropertyImageErrors
    {
        public static Error ExtentionFileInvalid { get; } = Error.Validation(
            code: "PropertyImage.File",
            description: "The extention of the file loaded is invalid only are availabe (jpg|jpeg|png)."
        );

        public static Error SizeFileInvalid { get; } = Error.Validation(
            code: "PropertyImage.File",
            description: "The size of the file loaded is invalid only it's availabe 50KB."
        );

        public static Error PropertyNotFound { get; } = Error.NotFound(
            code: "PropertyImage.IdProperty",
            description: "property not found, please review the identifier sended."
        );

        public static Error PathDirectoryNotGetted { get; } = Error.Validation(
            code: "PropertyImage.FilePath",
            description: "The path of directory not getted."
        );
    }
}
