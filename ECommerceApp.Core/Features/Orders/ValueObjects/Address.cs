using CSharpFunctionalExtensions;

namespace ECommerceApp.Core.Features.Orders.ValueObjects;

public record Address(string Street, string City, string State, string PostalCode, string Country)
{
    public static Result<Address> Create(string street, string city, string state, string postalCode, string country)
    {
        var result = Result.Combine
        (
            Result.FailureIf(string.IsNullOrWhiteSpace(street), $"[{nameof(street)}] cannot be empty."),
            Result.FailureIf(string.IsNullOrWhiteSpace(city), $"[{nameof(city)}] cannot be empty."),
            Result.FailureIf(string.IsNullOrWhiteSpace(state), $"[{nameof(state)}] cannot be empty."),
            Result.FailureIf(string.IsNullOrWhiteSpace(postalCode), $"[{nameof(postalCode)}] cannot be empty."),
            Result.FailureIf(string.IsNullOrWhiteSpace(country), $"[{nameof(country)}] cannot be empty.")
        );

        if (result.IsFailure)
            return result.ConvertFailure<Address>();

        return new Address(street, city, state, postalCode, country);
    }
}
