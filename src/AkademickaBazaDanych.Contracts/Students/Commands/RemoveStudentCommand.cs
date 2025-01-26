using AkademickaBazaDanych.Contracts.Students.Results;
using MediatR;

namespace AkademickaBazaDanych.Contracts.Students.Commands;
public record RemoveStudentCommand(string? IndexNumber) : IRequest<RemoveStudentResult>;
   

