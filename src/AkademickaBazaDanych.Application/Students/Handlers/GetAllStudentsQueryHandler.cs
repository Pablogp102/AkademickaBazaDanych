using AkademickaBazaDanych.Application.Students.Services;
using AkademickaBazaDanych.Contracts.Students.DTOs;
using AkademickaBazaDanych.Contracts.Students.Queries;

using MediatR;

namespace AkademickaBazaDanych.Application.Students.Handlers;
public sealed class GetAllStudentsQueryHandler(IStudentService studentService) : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDTO>>
{
    public async Task<IEnumerable<StudentDTO>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await studentService.GetAllStudents(request.SearchTerm, request.SortBy, request.IsAscending, request.PageNumber, request.PageSize);
        return students;
    }
}


