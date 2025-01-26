namespace AkademickaBazaDanych.Domain.Students;

public record Address
{
    public string? Street { get; private set; }
    public string? City { get; private set; }
    public string? PostalCode { get; private set; }
    public string? Country { get; private set; }
    public Address(string? street, string? city, string? postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Address properties cannot be null or empty.");

        Street = street;
        City = city;
        PostalCode = postalCode;
        Country = country;
    }
    public static Address Create(string street, string city, string postalCode, string country)
        => new Address(street, city, postalCode, country);
    public override int GetHashCode()
    {
        return HashCode.Combine(Street, City, PostalCode);
    }

    public override string ToString() => $"{Street}, {City}, {PostalCode}";
}


