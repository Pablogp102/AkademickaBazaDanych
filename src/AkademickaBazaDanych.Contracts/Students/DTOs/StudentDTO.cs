using AkademickaBazaDanych.Contracts.Students.Enums;

namespace AkademickaBazaDanych.Contracts.Students.DTOs;

public class StudentDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PESEL { get; set; }
    public string? IndexNumber { get; set; }
    public StudentDTO(string firstName, string lastName, string pesel, string indexNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PESEL = pesel;
        IndexNumber = indexNumber;
    }
}

public class StudentDetailsDTO : StudentDTO
{
    public string? Address { get; set; }
    public Gender? Gender { get; set; }
    public StudentDetailsDTO(string firstName, string lastName, string pesel, string indexNumber, string? address, Gender? gender)
            : base(firstName, lastName, pesel, indexNumber) 
    {
        Address = address;
        Gender = gender;
    }
}