using ErrorOr;

namespace MU.Domain.Entities.Properties
{
    public static class PropertyErrors
    {
        public static Error cannotCreateCodeInternal { get; } = Error.Validation(
            code: "Property.CodeInternal",
            description: "Not was possible build the code internal of the property, please review the data."
        );

        public static Error AddressWithBadFormat { get;  } = Error.Validation(
            code: "Property.Address",
            description: "Address is not valid."
        );

        public static Error ownerNotFound { get; } = Error.NotFound(
            code: "Property.IdOwner",
            description: "Owner not found, please review the identifier sended."
        );

        public static Error propertyNotFound { get; } = Error.NotFound(
            code: "Property.IdProperty",
            description: "property not found, please review the identifier sended."
        );
    }
}
