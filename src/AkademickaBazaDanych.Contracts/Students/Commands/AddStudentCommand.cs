using MediatR;
using AkademickaBazaDanych.Contracts.Students.Enums;
using AkademickaBazaDanych.Contracts.Students.Results;

namespace AkademickaBazaDanych.Contracts.Students.Commands;
public record AddStudentCommand() : IRequest<AddStudentResult>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public string? PESEL { get; init; }
    public Gender Gender { get; init; }
}

