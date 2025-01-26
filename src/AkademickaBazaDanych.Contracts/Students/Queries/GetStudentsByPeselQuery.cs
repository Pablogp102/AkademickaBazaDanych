using AkademickaBazaDanych.Contracts.Students.DTOs;
using MediatR;

namespace AkademickaBazaDanych.Contracts.Students.Queries;
public record GetStudentsByPeselQuery(string PeselPart) : IRequest<IEnumerable<StudentDetailsDTO>>;
 

