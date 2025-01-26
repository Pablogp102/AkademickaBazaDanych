using AkademickaBazaDanych.Contracts.Students.Enums;

namespace AkademickaBazaDanych.Contracts.Students.DTOs;

public class StudentDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PESEL { get; set; }
    public string? IndexNumber { get; set; }
}

public class StudentDetailsDTO : StudentDTO
{
    public string? Address { get; set; }
    public Gender? Gender { get; set; }
}