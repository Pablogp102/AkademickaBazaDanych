using AkademickaBazaDanych.Domain.Core;

namespace AkademickaBazaDanych.Domain.Students;
public class Student : AggregateRoot<Guid>
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public Address? Address { get; private set; }
    public IndexNumber? IndexNumber { get; }
    public Pesel? PESEL { get; }
    public string? Gender { get; }

    private Student(Guid id) : base(id) { }

    public Student(Guid id, string firstName, string lastName, Address? address, IndexNumber? indexNumber, Pesel? pesel, string gender) : base(id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        IndexNumber = indexNumber;
        PESEL = pesel;
        Gender = gender;
    }

    public static Student Create(Guid id, string firstName, string lastName, Address address, IndexNumber indexNumber, Pesel? pesel, string gender)
         => new Student(Guid.NewGuid(), firstName, lastName, address, indexNumber, pesel, gender);

    // In case of changes in personal data, the following methods are used:
    public void UpdateFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty.");

        FirstName = firstName;
    }

    public void UpdateLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty.");

        LastName = lastName;
    }

    public void UpdateAddress(Address address)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

}



