
using AkademickaBazaDanych.Contracts.Students.DTOs;
using MediatR;

namespace AkademickaBazaDanych.Contracts.Students.Queries;
public record GetStudentByLastNameQuery(string LastName) : IRequest<IEnumerable<StudentDetailsDTO>>;
  

