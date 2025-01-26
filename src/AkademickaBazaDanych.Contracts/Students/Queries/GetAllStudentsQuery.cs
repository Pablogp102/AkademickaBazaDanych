using AkademickaBazaDanych.Contracts.Students.DTOs;
using MediatR;

namespace AkademickaBazaDanych.Contracts.Students.Queries;
public record GetAllStudentsQuery() : IRequest<IEnumerable<StudentDTO>>;
    

