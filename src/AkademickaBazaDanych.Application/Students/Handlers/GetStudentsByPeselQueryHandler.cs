using AkademickaBazaDanych.Application.Students.Services;
using AkademickaBazaDanych.Contracts.Students.DTOs;
using AkademickaBazaDanych.Contracts.Students.Queries;

using MediatR;

namespace AkademickaBazaDanych.Application.Students.Handlers
{
    public class GetStudentsByPeselQueryHandler(IStudentService studentService) : IRequestHandler<GetStudentsByPeselQuery, IEnumerable<StudentDetailsDTO>>
    {
        public Task<IEnumerable<StudentDetailsDTO>> Handle(GetStudentsByPeselQuery request, CancellationToken cancellationToken)
            => studentService.GetStudentsByPESEL(request.PeselPart);
    }
}
