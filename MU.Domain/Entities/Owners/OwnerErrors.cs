using ErrorOr;

namespace MU.Domain.Entities.Owners
{
    public static class OwnerErrors
    {
        public static Error OwnerNotFound { get; } = Error.NotFound(
            code: "Owner.IdOwner",
            description: "Owner not found, please review the identifier sended."
        );

        public static Error AddressWithBadFormat { get; } = Error.Validation(
            code: "Owner.Address",
            description: "Address is not valid."
        );

        public static Error BirthayNotValid { get; } = Error.Validation(
            code: "Owner.Birthay",
            description: "Birthay Date is not valid."
        );
    }
}
