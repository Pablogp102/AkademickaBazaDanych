using AkademickaBazaDanych.Contracts.Students.DTOs;
using AkademickaBazaDanych.Contracts.Students.Enums;

using MediatR;

namespace AkademickaBazaDanych.Contracts.Students.Queries;
public record GetAllStudentsQuery(
    string? SearchTerm,
    SortingOptions? SortBy,  
    bool IsAscending, 
    int PageNumber,  
    int PageSize     
) : IRequest<IEnumerable<StudentDTO>>;


