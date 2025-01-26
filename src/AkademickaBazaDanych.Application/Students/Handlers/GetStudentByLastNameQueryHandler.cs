using AkademickaBazaDanych.Application.Students.Services;
using AkademickaBazaDanych.Contracts.Students.DTOs;
using AkademickaBazaDanych.Contracts.Students.Queries;

using MediatR;

namespace AkademickaBazaDanych.Application.Students.Handlers;
public sealed class GetStudentByLastNameQueryHandler(IStudentService studentService) : IRequestHandler<GetStudentByLastNameQuery, IEnumerable<StudentDetailsDTO>>
{
    public async Task<IEnumerable<StudentDetailsDTO>> Handle(GetStudentByLastNameQuery request, CancellationToken cancellationToken)
         => await studentService.GetStudentsByLastName(request.LastName ?? "");
    
}

